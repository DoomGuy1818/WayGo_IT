using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class AuthManager : MonoBehaviour
{
    public InputField emailInputField;
    public InputField passwordInputField;
    public Text messageText;

    private FirebaseAuth auth;

    private void Start()
    {
        // Инициализируем Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
        });
    }

    public void RegisterUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Создаем нового пользователя
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(HandleAuthResult);
    }

    public void LoginUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Вход пользователя
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(HandleAuthResult);
    }

    private void HandleAuthResult(Task<AuthResult> task)
    {
        if (task.IsCanceled)
        {
            Debug.LogError("Операция отменена.");
            messageText.text = "Операция отменена.";
            return;
        }
        if (task.IsFaulted)
        {
            Debug.LogError("Ошибка: " + task.Exception);
            messageText.text = "Ошибка: " + task.Exception;
            return;
        }

        FirebaseUser user = task.Result.User;
        Debug.LogFormat("Пользователь успешно зарегистрирован/вошел: {0} ({1})", user.DisplayName, user.UserId);
        messageText.text = "Пользователь успешно зарегистрирован/вошел: " + user.DisplayName;
    }
}
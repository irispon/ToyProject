using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class BackEndFederationAuth : MonoBehaviour
{
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration
            .Builder()
            .RequestServerAuthCode(false)
            .RequestEmail()                 // 이메일 요청
            .RequestIdToken()               // 토큰 요청
            .Build();

        //커스텀된 정보로 GPGS 초기화
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = false;

        //GPGS 시작.
        PlayGamesPlatform.Activate();
        GoogleAuth();
    }

    // 구글에 로그인하기
    private void GoogleAuth()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated == false)
        {
            Social.localUser.Authenticate(success =>
            {
                if (success == false)
                {
                    Debug.Log("구글 로그인 실패");
                    return;
                }

                // 로그인이 성공되었습니다.
                Debug.Log("GetIdToken - " + PlayGamesPlatform.Instance.GetIdToken());
                Debug.Log("Email - " + ((PlayGamesLocalUser)Social.localUser).Email);
                Debug.Log("GoogleId - " + Social.localUser.id);
                Debug.Log("UserName - " + Social.localUser.userName);
                Debug.Log("UserName - " + PlayGamesPlatform.Instance.GetUserDisplayName());
            });
        }
    }
    // 구글 토큰 받아오기
    private string GetTokens()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // 유저 토큰 받기 첫번째 방법
            string _IDtoken = PlayGamesPlatform.Instance.GetIdToken();
            // 두번째 방법
            // string _IDtoken = ((PlayGamesLocalUser)Social.localUser).GetIdToken();
            return _IDtoken;
        }
        else
        {
            Debug.Log("접속되어있지 않습니다. 잠시 후 다시 시도하세요.");
            GoogleAuth();
            return null;
        }
    }

    public void OnClickGPGSLogin()
    {
        //BackendReturnObject BRO = Backend.BMember.AuthorizeFederation(GetTokens(), FederationType.Google, "gpgs로 만든계정");
        //if (BRO.IsSuccess())
        //{
        //    Debug.Log("구글 토큰으로 뒤끝서버 로그인 성공 - 동기 방식-");
        //}
        //else
        //{
        //    switch (BRO.GetStatusCode())
        //    {
        //        case "200":
        //            Debug.Log("이미 회원가입된 회원");
        //            break;

        //        case "403":
        //            Debug.Log("차단된 사용자 입니다. 차단 사유 : " + BRO.GetErrorCode());
        //            break;
        //    }
        //}
    }
}
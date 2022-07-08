using Newtonsoft.Json.Linq;
using System;

namespace myChat.Service
{
    public sealed class  LoginModule
    {
        //로그인 모듈은 첫 생성시 하나만 있으면 되므로 SingleTone 방식으로 작성
        // Lazy 선언을 통해 호출시 생성되도록 변경한다.

        private LoginModule()
        {
            //생성 될 때 = 로그인 시도할 때.. 성공하면 로그인 모듈에 계정 정보를 가져온다.

        }
        private static readonly Lazy<LoginModule> _loginModule = new Lazy<LoginModule>(() => new LoginModule());

        public static LoginModule loginModule
        {
            get { return _loginModule.Value; }
        }

        public static myChatClass.LOGIN_STATUS Login(string sabun, string pw, string ip)
        {


            // 로그인은 Mysql DB서버로..

            //1. WAS로 로그인 요청해서 결과 받아오기 
            //   요청 형식.. JSON형태로 ID / PW 보내기
            //   결과값은 성공 : 1 실패 : 0
            //   
            string json = string.Empty;
            JObject jobj = new JObject(
                new JProperty("TYPE", "1"),
                new JProperty("SABUN", sabun),
                new JProperty("PW", pw),
                new JProperty("IP", ip)
                );

            Connector.DataTransfer(jobj.ToString());
            //if( myChatClass.LOGIN_STATUS.FAIL

            return myChatClass.LOGIN_STATUS.FAIL;
        }

        
    }
}

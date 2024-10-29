using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prj_Class0707.Conexion
{
    public class FirebaseDBConexion
    {
        public static FirebaseClient FireBase_Connect = new FirebaseClient("https://prj-class0707-default-rtdb.firebaseio.com/");
        public const string WepApyAuthentication = "AIzaSyBX0RJifeUSl6nr0tcRDu47k1GKHkxmAbY";

    }
}

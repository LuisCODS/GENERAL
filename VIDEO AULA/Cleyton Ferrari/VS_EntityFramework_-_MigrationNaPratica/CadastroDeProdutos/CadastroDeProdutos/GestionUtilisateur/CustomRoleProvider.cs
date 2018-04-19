//using CadastroDeProdutos.DAL;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using TP.Models.DataModels;

//namespace GestionDesAccess.Models
//{
//    public class CustomRoleProvider : RoleProvider
//    {

//        /*
//         Doit retourner un tableau de string contenant tous les rôles
//         par exemple return string[] {"admin", "user" }
//         */
//        public override string[] GetAllRoles()
//        {
//            Trace.WriteLine("get all roles");
//            //get names transforme les valeurs d'un enum en string
//            return Enum.GetNames(typeof(TypeUtilisateur));

//        }

//        /*
//            Doit retourner un tableau de tous les rôles possibles
//            username fait référence à l'information qu'on a placé dans le
//            cookie d'authentification (dans notre cas, le UtilisteurID).
//         */
//        public override string[] GetRolesForUser(string username)
//        {
//            Trace.WriteLine("get roles");
//            var context = new ProdutoContexto();
//            var user = context.Utilisateurs.Find(Int32.Parse(username));
//            if (user == null)
//            {
//                throw new Exception("Le cookie ne contient pas un UtilisateurID");
//            }
//            else
//            {
//                //il faut retourner un tableau de string
//                var role = user.TypeUtilisateur.ToString();
//                //on place donc la chaine role dans un tableau
//                return new string[] { role };
//            }
//        }

//        /*Vérifier que le paramètre username appartient au rôle roleName*/
//        public override bool IsUserInRole(string username, string roleName)
//        {
//            Trace.WriteLine("user in role");
//            var context = new ProdutoContexto();
//            var user = context.Utilisateurs.Find(Int32.Parse(username));
//            if (user == null)
//            {
//                throw new Exception("Le cookie ne contient pas un UtilisateurID.");
//            }
//            Trace.WriteLine(" user.TypeUtilisateur: {user.TypeUtilisateur.ToString()}");
//            Trace.WriteLine(" rolename: {roleName}");
//            if (user.TypeUtilisateur == (TypeUtilisateur)Enum.Parse(typeof(TypeUtilisateur), roleName))
//            {

//                return true;
//            }
//            return false;
//        }
//        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
//        {
//            throw new NotImplementedException();
//        }
//        public override string ApplicationName
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//            set
//            {
//                throw new NotImplementedException();
//            }
//        }
                       

//        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override void CreateRole(string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] GetUsersInRole(string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool RoleExists(string roleName)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
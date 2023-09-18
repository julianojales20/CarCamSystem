using Sistema_Vendas.DALdados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Vendas.BLLClasses
{
    class UserBll
    {
        public int id { get; set; }
        public string fist_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public string user_type { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }

        public int GetIDFromUsername(string username)
        {
            int userId = 0; // Valor padrão se o usuário não for encontrado

            // Acessar o banco de dados para obter o ID do usuário com base no nome de usuário
            UserDal UserDal = new UserDal();
            // Supondo que o método GetUserIDFromUsername na classe UserDAL retorne o ID do usuário
            userId = UserDal.GetIDFromUsername(username);

            return userId;
        }

    }
}

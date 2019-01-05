using System;
using System.Collections.Generic;
using System.Text;
using NoKnowApplication.Entities;

namespace NoKnowApplication.Models
{
    public static class ApplicationHandler
    {
        public static List<KantonEntity> Kantone;
        public static List<GemeindeEntity> Gemeinden;
        public static AccountEntity LoggedInAccount;
        public static AreaConfigurationEntity AreaConfiguration;
        public static List<AccountEntity> AllAccounts;
    }
}

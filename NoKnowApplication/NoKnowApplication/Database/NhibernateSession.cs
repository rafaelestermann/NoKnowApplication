using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace ashtonapp.Database
{
    public class NhibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Database\hibernate.cfg.xml");
            configuration.Configure(configurationPath);

            var assignmentconfigfile = HttpContext.Current.Server.MapPath("~/Database/Mappings/Assignment.hbm.xml");
            var assignmentdetailconfigfile = HttpContext.Current.Server.MapPath("~/Database/Mappings/AssignmentDetail.hbm.xml");
            var workerconfigfile = HttpContext.Current.Server.MapPath("~/Database/Mappings/Worker.hbm.xml");

            configuration.AddFile(assignmentconfigfile).AddFile(assignmentdetailconfigfile).AddFile(workerconfigfile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace WCFService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        DataTable GetCourierList();
       
        [OperationContract]
        void DelCourier(int id);

    }

    [ServiceContract]
    public interface IServTP
    {
        [OperationContract]
        DataTable GetSystemInfo(string param);
    }


    [ServiceContract]
    public interface IBoat
    {
        
        [OperationContract]
        double Sinn(Boat par);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.View_Model;

namespace UserManagement.Repository.Interface
{
    //Key sbg primary key, untuk ngecocokin key dengan entiy
    public interface IRepository<Entity, Key> where Entity : class
    {
        IEnumerable<Entity> Get(); //get all
        //ienum penampung kumpulan data, sifatnya seperti foreach
        Entity Get(Key key); //get by ID
        int Insert(Entity entity);
        int Update(Entity entity);
        int Delete(Key key);
        //RegisterVM Register(Key key);
    }
}

using Autofac;
using FactoryMehtodLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMehtodLib.Repository
{
    public interface IBoardAdminRepo : IRepository<BoardAdmin>
    {
    }
    public class BoardAdminRepo : Repository<BoardAdmin>, IBoardAdminRepo
    {
    }
}

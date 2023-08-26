using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Domain.Interfaces
{
    public interface IRepositoryUoW : IDisposable
    {
        IDoctorRepository Doctors { get; }
        ISpecialtyRepository Specialtys { get; } 

        void Commit();
        void Rowback();
    }
}

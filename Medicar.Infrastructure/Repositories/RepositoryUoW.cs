using Medicar.Domain.Interfaces;
using Medicar.Infrastructure.Contexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Infrastructure.Repositories
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private ApplicationDbContext _dbContext;
        private IDoctorRepository _doctorRepository;
        private ISpecialtyRepository _specialtyRepository;

        public RepositoryUoW(ApplicationDbContext context)
        {
            _dbContext = context;
            _doctorRepository = new DoctorRepository(context);
            _specialtyRepository = new SpecialtyRepository(context);
        }
        public IDoctorRepository Doctors => _doctorRepository;

        public ISpecialtyRepository Specialtys => _specialtyRepository;

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Rowback()
        {
            
        }
    }
}

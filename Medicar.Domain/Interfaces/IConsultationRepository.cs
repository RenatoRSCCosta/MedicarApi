using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Domain.Interfaces;

public interface IConsultationRepository
{
    Task<List<Consultation>> GetAllConsultations();
    Task<Consultation> GetConsultationById(int id);
    Task<Consultation> CreateConsultation(Consultation consultation);
    Task<Consultation> UpdateConsultation(Consultation consultation);
    Task DeleteConsultation(Consultation consultation);
}

using AutoMapper;
using Medicar.Application.Dtos.DoctorDtos;
using Medicar.Application.Interfaces;
using Medicar.Domain.Interfaces;
using Medicar.Domain.Return;
using Medicar_API.Domain.Entities;

namespace Medicar.Application.Services;

public class DoctorService : BaseService, IDoctorService
{
    private IDoctorRepository _doctorRepository;
    private IMapper _mapper;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;

    }

    public async Task<CustomReturn<DoctorDto>> GetAll()
    {
        string error = "Erro ao buscar medicos. Verificar notificações para mais informações.";
        string success = "Medicos encontrados com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<DoctorDto>();

        try
        {
            var doctors = await _doctorRepository.GetAll();

            result.SetData(_mapper.Map<DoctorDto>(doctors));
        }
        catch(Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<DoctorDto>> GetById(int id)
    {
        string error = "Erro ao buscar medico. Verificar notificações para mais informações.";
        string success = "Medico encontrado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<DoctorDto>();

        try
        {
            var doctor = await _doctorRepository.GetById(id);

            result.SetData(_mapper.Map<DoctorDto>(doctor));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<DoctorDto>> Add(PostDoctorDto doctorDto)
    {
        string error = "Erro ao cadastrar medico. Verificar notificações para mais informações.";
        string success = "Medico cadastrado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<DoctorDto>();

        try
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            var response = await _doctorRepository.Add(doctor);

            result.SetData(_mapper.Map<DoctorDto>(response));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<DoctorDto>> Update(DoctorDto doctorDto)
    {
        string error = "Erro ao atualizar medico. Verificar notificações para mais informações.";
        string success = "Medico atualizado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<DoctorDto>();

        try
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            if (doctor is not null) 
            {
                var response = await _doctorRepository.Update(doctor);

                result.SetData(_mapper.Map<DoctorDto>(response));
            }   
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<DoctorDto>> Delete(int id)
    {
        string error = "Erro ao remover medico. Verificar notificações para mais informações.";
        string success = "Medico removido com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<DoctorDto>();

        try
        {
            var doctor = await _doctorRepository.GetById(id);

            if (doctor is not null)
            {
                await _doctorRepository.Delete(doctor);

                result.SetData(_mapper.Map<DoctorDto>(doctor));
            }
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }
}

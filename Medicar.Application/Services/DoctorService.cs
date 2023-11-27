using AutoMapper;
using Medicar.Application.Dtos;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar.Application.Interfaces;
using Medicar.Domain.Interfaces;
using Medicar.Domain.Return;
using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Services;

public class DoctorService : BaseService, IDoctorService
{
    private IDoctorRepository _doctorRepository;
    private ISpecialtyRepository _specialtyRepository;
    private IMapper _mapper;

    public DoctorService(IDoctorRepository doctorRepository, ISpecialtyRepository specialtyRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _specialtyRepository = specialtyRepository;
        _mapper = mapper;

    }

    public async Task<CustomReturn<GetDoctorDto>> GetAllDoctors()
    {
        var result = new CustomReturn<GetDoctorDto>();

        string error = "Erro ao buscar medicos. Verificar notificações para mais informações.";
        string success = "Medicos encontrados com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var doctors = await _doctorRepository.GetAllDoctors();

            result.SetData(_mapper.Map<List<GetDoctorDto>>(doctors));
        }
        catch(Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<GetDoctorDto>> GetDoctorById(int id)
    {
        var result = new CustomReturn<GetDoctorDto>();

        string error = "Erro ao buscar medico. Verificar notificações para mais informações.";
        string success = "Medico encontrado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var doctor = await _doctorRepository.GetDoctorById(id);

            result.SetData(_mapper.Map<GetDoctorDto>(doctor));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<PostDoctorDto>> CreateDoctor(PostDoctorDto doctorDto)
    {
        var result = new CustomReturn<PostDoctorDto>();

        string error = "Erro ao cadastrar medico. Verificar notificações para mais informações.";
        string success = "Medico cadastrado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            var response = await _doctorRepository.CreateDoctor(doctor);

            result.SetData(_mapper.Map<PostDoctorDto>(response));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<PutDoctorDto>> UpdateDoctor(PutDoctorDto doctorDto)
    {
        var result = new CustomReturn<PutDoctorDto>();

        string error = "Erro ao atualizar medico. Verificar notificações para mais informações.";
        string success = "Medico atualizado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            if (doctor is not null) 
            {
                var response = await _doctorRepository.UpdateDoctor(doctor);

                result.SetData(_mapper.Map<PutDoctorDto>(response));
            }   
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<GetDoctorDto>> DeleteDoctor(int id)
    {
        var result = new CustomReturn<GetDoctorDto>();

        string error = "Erro ao remover medico. Verificar notificações para mais informações.";
        string success = "Medico removido com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var doctor = await _doctorRepository.GetDoctorById(id);

            if (doctor is not null)
            {
                await _doctorRepository.DeleteDoctor(doctor);

                result.SetData(_mapper.Map<GetDoctorDto>(doctor));
            }
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }
}

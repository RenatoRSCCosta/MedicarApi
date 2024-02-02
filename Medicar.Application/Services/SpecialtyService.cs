using AutoMapper;
using Medicar.Application.Dtos;
using Medicar.Application.Dtos.SpecialtyDtos;
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

public class SpecialtyService : BaseService, ISpecialtyService
{
    private ISpecialtyRepository _specialtyRepository;
    private IMapper _mapper;

    public SpecialtyService(ISpecialtyRepository specialtyRepository, IMapper mapper)
    {
        _specialtyRepository = specialtyRepository;
        _mapper = mapper;

    }

    public async Task<CustomReturn<SpecialtyDto>> GetAll()
    {
        string error = "Erro ao buscar especialidades. Verificar notificações para mais informações.";
        string success = "Especialidades encontradas com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SpecialtyDto>();

        try
        {
            var specialtys = await _specialtyRepository.GetAll();

            result.SetData(_mapper.Map<SpecialtyDto>(specialtys));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }
        
        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SpecialtyDto>> GetById(int id)
    {
        string error = "Erro ao buscar especialidade. Verificar notificações para mais informações.";
        string success = "Especialidade encontrada com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SpecialtyDto>();

        try
        {
            var specialty = await _specialtyRepository.GetById(id);

            result.SetData(_mapper.Map<SpecialtyDto>(specialty));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SpecialtyDto>> Add(PostSpecialtyDto specialtyDto)
    {
        string error = "Erro ao criar especialidade. Verificar notificações para mais informações.";
        string success = "Especialidades criada com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SpecialtyDto>();

        try
        {
            var specialty = _mapper.Map<Specialty>(specialtyDto);

            var response = await _specialtyRepository.Add(specialty);

            result.SetData(_mapper.Map<SpecialtyDto>(response));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SpecialtyDto>> Update(SpecialtyDto specialtyDto)
    {
        string error = "Erro ao atualizar especialidade. Verificar notificações para mais informações.";
        string success = "Especialidade atualizada encontradas com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SpecialtyDto>();

        try
        {
            var specialty = _mapper.Map<Specialty>(specialtyDto);

            var response = await _specialtyRepository.Update(specialty);

            result.SetData(_mapper.Map<SpecialtyDto>(result));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SpecialtyDto>> Delete(int id)
    {
        string error = "Erro ao remover especialidade. Verificar notificações para mais informações.";
        string success = "Especialidade removido com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SpecialtyDto>();

        try
        {
            var specialty = await _specialtyRepository.GetById(id);

            if (specialty is not null)
            {
                await _specialtyRepository.Delete(specialty);

                result.SetData(_mapper.Map<SpecialtyDto>(specialty));
            }
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }
}

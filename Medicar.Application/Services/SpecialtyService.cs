﻿using AutoMapper;
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

    public async Task<CustomReturn<SpecialtyDto>> GetAllSpecialtys()
    {
        var result = new CustomReturn<SpecialtyDto>();

        string error = "Erro ao buscar especialidades. Verificar notificações para mais informações.";
        string success = "Especialidades encontradas com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var specialtys = await _specialtyRepository.GetAllSpecialtys();

            result.SetData(_mapper.Map<List<SpecialtyDto>>(specialtys));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }
        
        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SpecialtyDto>> GetSpecialtyById(int id)
    {
        var result = new CustomReturn<SpecialtyDto>();

        string error = "Erro ao buscar especialidade. Verificar notificações para mais informações.";
        string success = "Especialidade encontrada com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var specialty = await _specialtyRepository.GetSpecialtyById(id);

            result.SetData(_mapper.Map<SpecialtyDto>(specialty));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<PostSpecialtyDto>> CreateSpecialty(PostSpecialtyDto specialtyDto)
    {
        var result = new CustomReturn<PostSpecialtyDto>();

        string error = "Erro ao criar especialidade. Verificar notificações para mais informações.";
        string success = "Especialidades criada com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var specialty = _mapper.Map<Specialty>(specialtyDto);

            var response = await _specialtyRepository.CreateSpecialty(specialty);

            result.SetData(_mapper.Map<PostSpecialtyDto>(result));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SpecialtyDto>> UpdateSpecialty(SpecialtyDto specialtyDto)
    {
        var result = new CustomReturn<SpecialtyDto>();

        string error = "Erro ao atualizar especialidade. Verificar notificações para mais informações.";
        string success = "Especialidade atualizada encontradas com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var specialty = _mapper.Map<Specialty>(specialtyDto);

            var response = await _specialtyRepository.UpdateSpecialty(specialty);

            result.SetData(_mapper.Map<SpecialtyDto>(result));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SpecialtyDto>> DeleteSpecialtyById(int id)
    {
        var result = new CustomReturn<SpecialtyDto>();

        string error = "Erro ao remover especialidade. Verificar notificações para mais informações.";
        string success = "Especialidade removido com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var specialty = await _specialtyRepository.GetSpecialtyById(id);

            if (specialty is not null)
            {
                await _specialtyRepository.DeleteSpecialty(specialty);

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

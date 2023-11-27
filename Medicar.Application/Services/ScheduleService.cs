using AutoMapper;
using FluentValidation;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar.Application.Interfaces;
using Medicar.Application.Validators;
using Medicar.Domain.Interfaces;
using Medicar.Domain.Return;
using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Services;

public class ScheduleService : BaseService, IScheduleService
{
    private IScheduleRepository _scheduleRepository;
    private ISlotRepository _slotRepository;
    private IMapper _mapper;

    public ScheduleService(IScheduleRepository scheduleRepository, ISlotRepository slotRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _slotRepository = slotRepository;
        _mapper = mapper;
    }

    public async Task<CustomReturn<PostScheduleDto>> CreateSchedule(PostScheduleDto scheduleDto)
    {
        var result = new CustomReturn<PostScheduleDto>();

        var validator = new ScheduleValidator(_scheduleRepository);

        string error = "Erro ao criar agenda. Verificar notificações para mais informações!";
        string success = "Agenda criada com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            await validator.ValidateAndThrowAsync(scheduleDto);

            var schedule = _mapper.Map<Schedule>(scheduleDto);

            var response = await _scheduleRepository.CreateSchedule(schedule);

            result.SetData(_mapper.Map<PostScheduleDto>(response));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<GetScheduleDto>> GetAllSchedules()
    {
        var result = new CustomReturn<GetScheduleDto>();

        string error = "Erro ao buscar agendas. Verificar notificações para mais informações.";
        string success = "Agendas encontradas com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        try
        {
            var schedules = await _scheduleRepository.GetAllSchedules();

            result.SetData(_mapper.Map<List<GetScheduleDto>>(schedules));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }
}

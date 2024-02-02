using AutoMapper;
using FluentValidation;
using Medicar.Application.Dtos.ScheduleDtos;
using Medicar.Application.Interfaces;
using Medicar.Application.Validators;
using Medicar.Domain.Interfaces;
using Medicar.Domain.Return;
using Medicar_API.Domain.Entities;

namespace Medicar.Application.Services;

public class ScheduleService : BaseService, IScheduleService
{
    private IScheduleRepository _scheduleRepository;
    private IMapper _mapper;

    public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<CustomReturn<ScheduleDto>> GetAll()
    {
        string error = "Erro ao buscar agendas. Verificar notificações para mais informações.";
        string success = "Agendas encontradas com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<ScheduleDto>();

        try
        {
            var schedules = await _scheduleRepository.GetAll();

            result.SetData(_mapper.Map<ScheduleDto>(schedules));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<ScheduleDto>> Add(PostScheduleDto scheduleDto)
    {
        string error = "Erro ao criar agenda. Verificar notificações para mais informações!";
        string success = "Agenda criada com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<ScheduleDto>();

        var validator = new ScheduleValidator(_scheduleRepository);

        try
        {
            await validator.ValidateAndThrowAsync(scheduleDto);

            var schedule = _mapper.Map<Schedule>(scheduleDto);

            var response = await _scheduleRepository.Add(schedule);

            result.SetData(_mapper.Map<ScheduleDto>(response));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }
}

using AutoMapper;
using Medicar.Application.Dtos.SlotDtos;
using Medicar.Application.Interfaces;
using Medicar.Domain.Interfaces;
using Medicar.Domain.Return;
using Medicar_API.Domain.Entities;

namespace Medicar.Application.Services;

public class SlotService : BaseService, ISlotService
{
    private ISlotRepository _slotRepository;
    private IMapper _mapper;

    public SlotService(ISlotRepository slotRepository, IMapper mapper)
    {
        _slotRepository = slotRepository;
        _mapper = mapper;

    }

    public async Task<CustomReturn<SlotDto>> GetSlotsBySchedule(int scheduleId)
    {
        string error = "Erro ao buscar horarios. Verificar notificações para mais informações.";
        string success = "Horarios encontrados com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SlotDto>();

        try
        {
            var slotsBySchedule = await _slotRepository.GetSlotsByScheduleId(scheduleId);

            result.SetData(_mapper.Map<SlotDto>(slotsBySchedule));
        }
        catch(Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SlotDto>> GetById(int id)
    {
        string error = "Erro ao buscar horario. Verificar notificações para mais informações.";
        string success = "Horario encontrado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SlotDto>();

        try
        {
            var slot = await _slotRepository.GetById(id);

            result.SetData(_mapper.Map<SlotDto>(slot));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SlotDto>> Add(PostSlotDto slotDto)
    {
        string error = "Erro ao cadastrar horario. Verificar notificações para mais informações.";
        string success = "Horario cadastrado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SlotDto>();

        try
        {
            var slot = _mapper.Map<Slot>(slotDto);

            var response = await _slotRepository.Add(slot);

            result.SetData(_mapper.Map<SlotDto>(response));
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SlotDto>> Update(SlotDto slotDto)
    {
        string error = "Erro ao atualizar horario. Verificar notificações para mais informações.";
        string success = "Horario atualizado com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SlotDto>();

        try
        {
            var slot = _mapper.Map<Slot>(slotDto);

            if (slot is not null) 
            {
                var response = await _slotRepository.Update(slot);

                result.SetData(_mapper.Map<SlotDto>(response));
            }   
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }

    public async Task<CustomReturn<SlotDto>> Delete(int id)
    {
        string error = "Erro ao remover horario. Verificar notificações para mais informações.";
        string success = "Horario removido com sucesso!";
        string noDataFound = "Dados não encontrados na base!";

        var result = new CustomReturn<SlotDto>();

        try
        {
            var slot = await _slotRepository.GetById(id);

            if (slot is not null)
            {
                await _slotRepository.Delete(slot);

                result.SetData(_mapper.Map<SlotDto>(slot));
            }
        }
        catch (Exception ex)
        {
            result = ManageException(result, ex);
        }

        return SetFeedbackMessage(result, error, noDataFound, success);
    }
}

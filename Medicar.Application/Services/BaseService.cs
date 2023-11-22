using Medicar.Domain.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Services;

public class BaseService
{
    protected CustomReturn<T> ManageException<T>(CustomReturn<T> result, Exception inputException)
    {
        if (inputException.GetType() == typeof(AggregateException))
        {
            inputException = inputException.InnerException;
        }
        var name = inputException.GetType().Name;
        switch (inputException.GetType().Name)
        {
            case "DbUpdateException":
                result.Notifications.Add(new ReturnError()
                {
                    Type = "Database",
                    Message = inputException.InnerException.Message
                });
                break;
            case "ApplicationException":
                result.Notifications.Add(new ReturnError()
                {
                    Type = "Generic",
                    Message = inputException.Message
                });
                break;
            case "ValidationException":
                result.Notifications.Add(new ReturnError()
                {
                    Type = "Validation",
                    Message = inputException.Message
                });
                break;
            default:
                throw inputException;
        }

        return result;
    }

    protected CustomReturn<T> SetFeedbackMessage<T>(CustomReturn<T> result, string error, string noDataFound, string success, bool dataCanBeNull = false)
    {
        if (result.Notifications.Count > 0)
        {
            result.Feedback = error;
            result.Status = HttpStatusCode.BadRequest;
        }
        else
        {
            if (dataCanBeNull || (!dataCanBeNull && result.Data != null))
            {
                result.Feedback = success;
                result.Status = HttpStatusCode.OK;
            }
            else
            {
                result.Feedback = noDataFound;
                result.Status = HttpStatusCode.NotFound;
            }
        }
        return result;
    }
}


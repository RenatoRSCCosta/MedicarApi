using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Domain.Return;

public class CustomReturn<T>
{
    public List<T> Data { get; set; }
    public long Total { get; set; }
    public long ResponseTime {  get; set; }
    public string Feedback { get; set; }
    public HttpStatusCode Status { get; set; }
    public List<ReturnError> Notifications { get; set; }

    public CustomReturn()
    {
            Notifications = new List<ReturnError>();
    }

    public void SetData(List<T> data)
    {
        if (data == null || data.Count == 0) Data = null;
        else Data = data;

        if(data == null) Total = 0;
        else Total = data.Count;
    }

    public void SetData(T data)
    {
        if (data == null) Data = null;
        else Data = new List<T> { data };

        if (data == null) Total = 0;
        else Total = 1;
    }
}

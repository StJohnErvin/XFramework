﻿using System.Net;

namespace XFramework.Domain.Generic.BusinessObjects
{
    public class QueryResponse<T>
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Response { get; set; }
    }
}
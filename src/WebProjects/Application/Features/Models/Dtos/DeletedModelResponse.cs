﻿using Core.Application.Responses;

namespace Application.Features.Models.Dtos;

public class DeletedModelResponse : IResponse
{
    public int Id { get; set; }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Utilities.Results;

public class SuccessDataResult<T> : DataResult<T>
{
    //data true ve mesaj
    public SuccessDataResult(T data, string message) : base(data, true, message)
    {

    }
    //data ve true
    public SuccessDataResult(T data) : base(data, true)
    {

    }

    public SuccessDataResult(string message) : base(default, true, message)
    {

    }

    public SuccessDataResult():base(default, true)
    {
        
    }
}

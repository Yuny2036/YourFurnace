using System;

public interface ITransferable<T>
{
    void TransferData(T package);
}

namespace Application.Exceptions
{
    class NotFoundException(string name, object key) : Exception($"{name} ({key}) is not found")
    {

    }
}

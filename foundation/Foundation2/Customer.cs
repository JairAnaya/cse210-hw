using System;
using System.Collections.Generic;

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetCustomerLabel()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}
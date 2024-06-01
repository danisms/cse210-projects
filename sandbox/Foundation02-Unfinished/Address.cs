public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private string _home;
    private List<string> _homeStates = new List<string>();

    // Constructors
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
        // set default home (USA)
        _home = "USA";
        // set default home states (states in USA)
        _homeStates = [
            "Alabama",
            "Alaska",
            "Arizona",
            "Arkansas",
            "California",
            "Colorado",
            "Connecticut",
            "Delaware",
            "Florida",
            "Georgia",
            "Hawaii",
            "Idaho",
            "Illinois",
            "Indiana",
            "Iowa",
            "Kansas",
            "Kentucky",
            "Louisiana",
            "Maine",
            "Maryland",
            "Massachusetts",
            "Michigan",
            "Minnesota",
            "Mississippi",
            "Missouri",
            "Montana",
            "Nebraska",
            "Nevada",
            "New Hampshire",
            "New Jersey",
            "New Mexico",
            "New York",
            "North Carolina",
            "North Dakota",
            "Ohio",
            "Oklahoma",
            "Oregon",
            "Pennsylvania",
            "Rhode Island",
            "South Carolina",
            "South Dakota",
            "Tennessee",
            "Texas",
            "Utah",
            "Vermont",
            "Virginia",
            "Washington",
            "West Virginia",
            "Wisconsin",
            "Wyoming",
            "District of Columbia"
        ];
    }

    // methods
    public void SetHome(string countryName)
    {
        _home = countryName;
    }

    public string GetHome()
    {
        return _home;
    }

    public void SetHomeState(List<string> states)
    {
        _homeStates = states;
    }

    public bool InHome()
    {
        bool inHome = false;
        // check if country provided match homeCountry
        if (_country.ToLower() == _home.ToLower())
        {
            // check if state provided is found in home states
            foreach (string homeState in _homeStates)
            {
                if (_state.ToLower() == homeState.ToLower())
                {
                    inHome = true;
                    break;
                }
            }
        }

        // return checked value of inHome
        return inHome;
    }

    public string GetAddress()
    {
        string address = $"{_street}, {_city}, {_state}, {_country}.";

        return address;
    }
}
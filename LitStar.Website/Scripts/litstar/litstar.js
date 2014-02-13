var baseUrl = "http://alpine.localhost/";

function CurrentDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } today = mm + '/' + dd + '/' + yyyy + " " + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    return today;
}

function dateToWcf(input) {
    var d = new Date(input);
    if (isNaN(d)) return null;
    return '\/Date(' + d.getTime() + '-0000)\/';
}

function Staff() {
    this.ID = 0;
    this.Email = "";
    this.FirstName = "";
    this.LastName = "";
    this.Title = "";
    this.Phone = "";
    this.HireDate = CurrentDate();
    this.TerminationDate = CurrentDate();
    this.Birthdate = CurrentDate();
    this.ManagerID = 0;
    this.PayRate = 0.0;
    this.PayFrequency = 1;
    this.UserID = 0;
    this.IsManager = false;
    this.IsActive = false;
    this.AvatarPath = "";
    this.AccountID = 0;
    this.ChangedBy = 0;
    this.EnteredBy = 0;
    this.LastUpdated = CurrentDate();
    this.DateCreated = CurrentDate();
    this.Address1 = "";
    this.Address2 = "";
    this.City = "";
    this.State = "";
    this.Zip = "";
    this.AccessLevel = 0;
}

function User() {
    this.ID = 0;
    this.Type = 0;
    this.Password = "";
    this.SecurityQuestion = "";
    this.SecurityAnswer = "";
    this.AccessLevel = 0;
    this.AccountID = 0;
    this.LastLoggedIn = CurrentDate();
    this.DateCreated = CurrentDate();
    this.LastUpdated = CurrentDate();
    this.EnteredBy = 0;
    this.ChangedBy = 0;
    this.Username = "";
}

function Learner() {
    this.ID = 0;
    this.Email = "";
    this.FirstName = "";
    this.LastName = "";
    this.Birthdate = CurrentDate();
    this.IsActive = false;
    this.AvatarPath = "";
    this.AccountID = 0;
    this.ChangedBy = 0;
    this.EnteredBy = 0;
    this.LastUpdated = CurrentDate();
    this.DateCreated = CurrentDate();
    this.Phone = "";
    this.Address1 = "";
    this.Address2 = "";
    this.City = "";
    this.State = "";
    this.Zip = "";
    this.AccessLevel = 0;
    this.Sex = false;
    this.Ethnicity = false;
    this.IsBillingual = false;
    this.IsCitizen = false;
    this.HasChildren = false;
    this.EducationCompleted = 0;
    this.Occupation = "";
    this.ReferredBy = "";
    this.Employer = "";
    this.EmergencyContactName = "";
    this.EmergencyContactPhone = "";
    this.PlaceOfBirth = "";
    this.ReasonForTutoring = "";
}

function Tutor() {
    this.ID = 0;
    this.Email = "";
    this.FirstName = "";
    this.LastName = "";
    this.Birthdate = CurrentDate();
    this.IsActive = false;
    this.AvatarPath = "";
    this.AccountID = 0;
    this.ChangedBy = 0;
    this.EnteredBy = 0;
    this.LastUpdated = CurrentDate();
    this.DateCreated = CurrentDate();
    this.Phone = "";
    this.Address1 = "";
    this.Address2 = "";
    this.City = "";
    this.State = "";
    this.Zip = "";
    this.AccessLevel = 0;
    this.Sex = false;
    this.Ethnicity = false;
    this.IsBillingual = false;
    this.EducationCompleted = 0;
    this.Occupation = "";
    this.ReferredBy = "";
    this.EmergencyContactName = "";
    this.EmergencyContactPhone = "";
}

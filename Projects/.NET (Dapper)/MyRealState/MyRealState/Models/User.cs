using System;

namespace MyRealState.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HousingTypePreference { get; set; }
        public int RoommatesCountPreference { get; set; }
        public string LocationPreference { get; set; }
        public decimal RentBudgetPreference { get; set; }
        public string StudyHabits { get; set; }
        public string CleanlinessPreference { get; set; }
        public string WorkOrClassSchedule { get; set; }
        public string DietaryPreferences { get; set; }
        public string InterestI { get; set; }
        public string InterestII { get; set; }
        public string InterestIII { get; set; }
        public string HobbieI { get; set; }
        public string HobbieII { get; set; }
        public string HobbieIII { get; set; }
        public string CulturalPreferenceI { get; set; }
        public string CulturalPreferenceII { get; set; }
        public string CulturalPreferenceIII { get; set; }
        public string PersonalityType { get; set; }
        public bool SocialCompatibility { get; set; }
        public bool NoiseTolerance { get; set; }
        public bool PartyAttitude { get; set; }
        public string Pets { get; set; }
        public string Allergies { get; set; }
        public bool PreviousRoommateExperience { get; set; }
        public string ReasonForMoving { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string CulturalOrReligiousPreferences { get; set; }
    }
}

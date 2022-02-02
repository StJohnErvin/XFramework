namespace XFramework.Client.Shared.Entity.Models.Components;

public class EndPointsModel
{
    public EndPointsModel()
    {
        _version = 1.0m;
    }
    public EndPointsModel(decimal version)
    {
        _version = version;
    }

    private static decimal _version = 1.0m;
    private static string OdataVersion = $"V{_version}/";
    public const string BaseUrl = "https://devhcm1080lh-backend.azurewebsites.net";
    public readonly string ODataBatch = $"{BaseUrl}/odata/$batch";
    public readonly string Authentication = $"{BaseUrl}/api/Auth/login";
    public readonly string TokenRefresh = $"{BaseUrl}/api/Auth/refreshtoken";
    public readonly string TenantAccountPersonaUserRoles = $"{BaseUrl}/api/TenantAccountPersonaUserRoles/";
    public readonly string TenantAccountPersonaRoleBubbleModules = $"{BaseUrl}/api/TenantAccountPersonaRoleBubbleModules/";
    public readonly string CandidateEmployee = $"{BaseUrl}/odata/CandidateEmployees";
    public readonly string CandidateEmployeeFiles = $"{BaseUrl}/odata/CandidateEmployeeFiles/";
    public readonly string TenantFileStorage = $"{BaseUrl}/odata/TenantFileStorage";
    public readonly string ODataTitles = $"{BaseUrl}/odata/Titles";
    public readonly string ODataGenders = $"{BaseUrl}/odata/Genders";
    public readonly string ODataStatuses = $"{BaseUrl}/odata/Statuses";
    public readonly string CandidateEmployeeList = $"{BaseUrl}/odata/CandidateEmployeeList";
    public readonly string ODataCandidateEmployeeBankAccounts = $"{BaseUrl}/odata/CandidateEmployeeBankAccounts";
    public readonly string ODataCandidateEmployeeSuperfunds = $"{BaseUrl}/odata/CandidateEmployeeSuperfunds";
    public readonly string ODataContacts = $"{BaseUrl}/odata/Contacts";
    public readonly string ODataLocations = $"{BaseUrl}/odata/Locations";
    public readonly string ODataAddresses = $"{BaseUrl}/odata/Addresses";
    public readonly string ODataGoogleAddresses = $"{BaseUrl}/odata/GoogleAddresses";
    public readonly string ODataGoogleAddressesGetDetails = $"{BaseUrl}/odata/GoogleAddresses/GetDetails";
    public readonly string ODataGoogleAddressesSearch = $"{BaseUrl}/odata/GoogleAddresses/Search";
    public readonly string ODataCustomerVendorAccountContactFiles = $"{BaseUrl}/odata/CustomerVendorAccountContactFiles";
    public readonly string ODataCustomerVendorAccounts = $"{BaseUrl}/odata/CustomerVendorAccounts";
    public readonly string ODataDeductionPayCategoryCandidateEmployees = $"{BaseUrl}/odata/DeductionPayCategoryCandidateEmployees";
    public readonly string ODataDriversLicenses = $"{BaseUrl}/odata/DriversLicenses";
    public readonly string ODataEmergencyContacts = $"{BaseUrl}/odata/EmergencyContacts";
    public readonly string ODataEntitlementCandidateEmployees = $"{BaseUrl}/odata/EntitlementCandidateEmployees";
    public readonly string ODataMasterVisaCategories = $"{BaseUrl}/odata/MasterVisaCategories";
    public readonly string ODataMasterVisaTypes = $"{BaseUrl}/odata/MasterVisaTypes";
    public readonly string ODataMasterVisaWorkHourTypes = $"{BaseUrl}/odata/MasterVisaWorkHourTypes";
    public readonly string ODataPassports = $"{BaseUrl}/odata/Passports";
    public readonly string ODataServer = $"{BaseUrl}/odata/Server";
    public readonly string ODataTFNDeclarations = $"{BaseUrl}/odata/TFNDeclarations";
    public readonly string ODataVaccinationDetails = $"{BaseUrl}/odata/VaccinationDetails";
    public readonly string ODataVaccinations = $"{BaseUrl}/odata/Vaccinations";
    public readonly string ODataVaccinationTypes = $"{BaseUrl}/odata/VaccinationTypes";
    public readonly string ODataVaccines = $"{BaseUrl}/odata/Vaccines";
    public readonly string ODataVisaCategories = $"{BaseUrl}/odata/VisaCategories";
    public readonly string ODataVisas = $"{BaseUrl}/odata/Visas";
    public readonly string ODataVisaTypes = $"{BaseUrl}/odata/VisaTypes";
    public readonly string ODataVisaWorkHourTypes = $"{BaseUrl}/odata/VisaWorkHourTypes";
    public readonly string ODataWhiteCards = $"{BaseUrl}/odata/WhiteCards";
    public readonly string ODataRelationships = $"{BaseUrl}/odata/Relationships";
    public readonly string ODataServerTime = $"{BaseUrl}/odata/Server";
    public readonly string ODataPayCycles = $"{BaseUrl}/odata/PayCycles";
    public readonly string ODataPayCyclePeriod = $"{BaseUrl}/odata/PayCyclePeriods";
    public readonly string ODataPayCyclePeriodHeader = $"{BaseUrl}/odata/PayCyclePeriodHeaders";
    public readonly string ODataRoster = $"{BaseUrl}/odata/JobCycles";
    public readonly string ODataRosterEmployee = $"{BaseUrl}/odata/RosterEmployees";
    public readonly string ODataJob = $"{BaseUrl}/odata/Jobs";
    public readonly string ODataJobLocation = $"{BaseUrl}/odata/JobLocations";
    public readonly string ODataJobShift = $"{BaseUrl}/odata/JobShifts";
    public readonly string ODataShift = $"{BaseUrl}/odata/Shifts";
    public readonly string ODataJobCycleSchedule = $"{BaseUrl}/odata/JobCycleSchedules";
    public readonly string ODataJobCycleDay = $"{BaseUrl}/odata/JobCycleDays";
    public readonly string ODataJobCycleDayBreak = $"{BaseUrl}/odata/JobCycleDayBreaks";
    public readonly string Breaks = $"{BaseUrl}/odata/Breaks";
    public readonly string ODataCreateRosterSchedule = $"{BaseUrl}/odata/JobCycleSchedules/CreateRosterSchedule";
    public readonly string ODataRosterDetail = $"{BaseUrl}/odata/JobCycleScheduleDetails";
    public readonly string ODataCallTypes = $"{BaseUrl}/odata/CallTypes";
    public readonly string ODataAccountManagementTypes = $"{BaseUrl}/odata/AccountManagementTypes";
    public readonly string ODataActivityData = $"{BaseUrl}/odata/ActivityData";
    public readonly string ODataActivityLinkTables = $"{BaseUrl}/odata/ActivityLinkTables";
    public readonly string ODataActivityParticipants = $"{BaseUrl}/odata/ActivityParticipants";
    public readonly string ODataActivityRecurrenceDates = $"{BaseUrl}/odata/ActivityRecurrenceDates";
    public readonly string ODataActivityRecurrenceFrequencies = $"{BaseUrl}/odata/ActivityRecurrenceFrequencies";
    public readonly string ODataActivityRecurrenceStatuses = $"{BaseUrl}/odata/ActivityRecurrenceStatuses";
    public readonly string ODataActivityRecurrences = $"{BaseUrl}/odata/ActivityRecurrences";
    public readonly string ODataActivitySubTypes = $"{BaseUrl}/odata/ActivitySubTypes";
    public readonly string ODataActivityTypeControls = $"{BaseUrl}/odata/ActivityTypeControls";
    public readonly string ODataActivityTypes = $"{BaseUrl}/odata/ActivityTypes";
    public readonly string ODataAllowances = $"{BaseUrl}/odata/Allowances";
    public readonly string ODataApplicableRates = $"{BaseUrl}/odata/ApplicableRates";
    public readonly string ODataAtoReportTypes = $"{BaseUrl}/odata/AtoReportTypes";
    public readonly string ODataAwardDetailsClassificationCategories = $"{BaseUrl}/odata/AwardDetailsClassificationCategories";
    public readonly string ODataAwardDetailsClassificationRates = $"{BaseUrl}/odata/AwardDetailsClassificationRates";
    public readonly string ODataAwardDetailsClassificationSubCategories = $"{BaseUrl}/odata/AwardDetailsClassificationSubCategories";
    public readonly string ODataAwardDetailsClassifications = $"{BaseUrl}/odata/AwardDetailsClassifications";
    public readonly string ODataAwardDetailsOvertimeStates = $"{BaseUrl}/odata/AwardDetailsOvertimeStates";
    public readonly string ODataAwardDetailsStates = $"{BaseUrl}/odata/AwardDetailsStates";
    public readonly string ODataAwardEmploymentTypes = $"{BaseUrl}/odata/AwardEmploymentTypes";
    public readonly string ODataAwards = $"{BaseUrl}/odata/Awards";
    public readonly string ODataBankAccounts = $"{BaseUrl}/odata/BankAccounts";
    public readonly string ODataBreaks = $"{BaseUrl}/odata/Breaks";
    public readonly string ODataCallPurposes = $"{BaseUrl}/odata/CallPurposes";
    public readonly string ODataCallSchedules = $"{BaseUrl}/odata/CallSchedules";
    public readonly string ODataCalls = $"{BaseUrl}/odata/Calls";
    public readonly string ODataCandidateEmployeeEmails = $"{BaseUrl}/odata/CandidateEmployeeEmails";
    public readonly string ODataCandidateEmployeeJobProfiles = $"{BaseUrl}/odata/CandidateEmployeeJobProfiles";
    public readonly string ODataCandidateEmployeeJobShifts = $"{BaseUrl}/odata/CandidateEmployeeJobShifts";
    public readonly string ODataCandidateEmployeeJobs = $"{BaseUrl}/odata/CandidateEmployeeJobs";
    public readonly string ODataCandidateEmployeePushNotifications = $"{BaseUrl}/odata/CandidateEmployeePushNotifications";
    public readonly string ODataCandidateEmployeeTypeCategories = $"{BaseUrl}/odata/CandidateEmployeeTypeCategories";
    public readonly string ODataCandidateEmployeeTypes = $"{BaseUrl}/odata/CandidateEmployeeTypes";
    public readonly string ODataCities = $"{BaseUrl}/odata/Cities";
    public readonly string ODataClassificationInfo = $"{BaseUrl}/odata/ClassificationInfo";
    public readonly string ODataColors = $"{BaseUrl}/odata/Colors";
    public readonly string ODataCompletedCalls = $"{BaseUrl}/odata/CompletedCalls";
    public readonly string ODataContactProfiles = $"{BaseUrl}/odata/ContactProfiles";
    public readonly string ODataControls = $"{BaseUrl}/odata/Controls";
    public readonly string ODataCounters = $"{BaseUrl}/odata/Counters";
    public readonly string ODataCountries = $"{BaseUrl}/odata/Countries";
    public readonly string ODataCurrentCalls = $"{BaseUrl}/odata/CurrentCalls";
    public readonly string ODataCustomerEmployees = $"{BaseUrl}/odata/CustomerEmployees";
    public readonly string ODataCustomerHr = $"{BaseUrl}/odata/CustomerHr";
    public readonly string ODataCustomerLeadAwards = $"{BaseUrl}/odata/CustomerLeadAwards";
    public readonly string ODataCustomerProfiles = $"{BaseUrl}/odata/CustomerProfiles";
    public readonly string ODataCustomerVendorAccountCandidateEmployees = $"{BaseUrl}/odata/CustomerVendorAccountCandidateEmployees";
    public readonly string ODataCustomerVendorAccountFiles = $"{BaseUrl}/odata/CustomerVendorAccountFiles";
    public readonly string ODataSmsTemplates = $"{BaseUrl}/odata/SmsTemplates";
    public readonly string EmailTemplates = $"{BaseUrl}/odata/EmailTemplates";
    public readonly string PushNotificationTemplatesTemplates = $"{BaseUrl}/odata/PushNotificationTemplates";
    public readonly string BubbleModules = $"{BaseUrl}/api/BubbleModules";
    public readonly string WebUIObjects = $"{BaseUrl}/api/WebUIObjects";
    public readonly string ODataAwardDetailsClassificationCategoryEmploymentTypes = $"{BaseUrl}/odata/AwardDetailsClassificationCategoryEmploymentTypes";
    public readonly string ODataDaysOfWeeks = $"{BaseUrl}/odata/DaysOfWeeks";
    public readonly string ODataDeductionPayCategories = $"{BaseUrl}/odata/DeductionPayCategories";
    public readonly string ODataDefaultSuperFunds = $"{BaseUrl}/odata/DefaultSuperFunds";
    public readonly string ODataEmailTemplates = $"{BaseUrl}/odata/EmailTemplates";
    public readonly string ODataEmployeeAddresses = $"{BaseUrl}/odata/EmployeeAddresses";
    public readonly string ODataEmployeeFiles = $"{BaseUrl}/odata/EmployeeFiles";
    public readonly string ODataEmployees = $"{BaseUrl}/odata/Employees";
    public readonly string ODataEmploymentTypeDefinitions = $"{BaseUrl}/odata/EmploymentTypeDefinitions";
    public readonly string ODataEntitlementJobs = $"{BaseUrl}/odata/EntitlementJobs";
    public readonly string ODataEntitlements = $"{BaseUrl}/odata/Entitlements";
    public readonly string ODataExpensePayCategories = $"{BaseUrl}/odata/ExpensePayCategories";
    public readonly string ODataExpensePayCategoryAwardDetailsClassifications = $"{BaseUrl}/odata/ExpensePayCategoryAwardDetailsClassifications";
    public readonly string ODataExpensePayCategoryBreaks = $"{BaseUrl}/odata/ExpensePayCategoryBreaks";
    public readonly string ODataExpensePayCategoryOvertimes = $"{BaseUrl}/odata/ExpensePayCategoryOvertimes";
    public readonly string ODataFormulaTables = $"{BaseUrl}/odata/FormulaTables";
    public readonly string ODataFormulaTypes = $"{BaseUrl}/odata/FormulaTypes";
    public readonly string SystemDefinedVariables = $"{BaseUrl}/odata/SystemDefinedVariables";
    public readonly string ODataServerGetDateOffset = $"{BaseUrl}/odata/Server/CFGetDateOffset";
    public readonly string AllocateMultipleEmployees = $"{BaseUrl}/odata/JobCycleScheduleDetailEmployees/CFAllocateMultitpleEmployees";
    public readonly string PayeeStatuses = $"{BaseUrl}/odata/PayeeStatuses";
    public readonly string PaymentBases = $"{BaseUrl}/odata/PaymentBases";
    public readonly string PublicHolidays = $"{BaseUrl}/odata/PublicHolidays";
    public readonly string PublicHolidayTypes = $"{BaseUrl}/odata/PublicHolidayTypes";
    public readonly string StageCategories = $"{BaseUrl}/odata/StageCategories";
    public readonly string StageTypes = $"{BaseUrl}/odata/StageTypes";
    public readonly string States = $"{BaseUrl}/odata/States";
    public readonly string Superfunds = $"{BaseUrl}/odata/Superfunds";
    public readonly string TaxRuleSets = $"{BaseUrl}/odata/TaxRuleSets";
    public readonly string TaxTableDetails = $"{BaseUrl}/odata/TaxTableDetails";
    public readonly string TaxTableHeaders = $"{BaseUrl}/odata/TaxTableHeaders";
    public readonly string TaxTables = $"{BaseUrl}/odata/TaxTables";
    public readonly string TenantBsb = $"{BaseUrl}/odata/TenantBsb";
    public readonly string TenantFiles = $"{BaseUrl}/odata/TenantFiles";
    public readonly string ThresholdTypes = $"{BaseUrl}/odata/ThresholdTypes";
    public readonly string TimeZoneInfo = $"{BaseUrl}/odata/TimeZoneInfo";
    public readonly string Titles = $"{BaseUrl}/odata/Titles";
    public readonly string MasterActivityDataValues = $"{BaseUrl}/odata/MasterActivityDataValues";
    public readonly string MasterActivityData = $"{BaseUrl}/odata/MasterActivityData";
    public readonly string MasterActivityRecurrenceFrequencies = $"{BaseUrl}/odata/MasterActivityRecurrenceFrequencies";
    public readonly string MasterActivitySubTypes = $"{BaseUrl}/odata/MasterActivitySubTypes";
    public readonly string MasterActivityTypeControls = $"{BaseUrl}/odata/MasterActivityTypeControls";
    public readonly string MasterActivityTypes = $"{BaseUrl}/odata/MasterActivityTypes";
    public readonly string MasterAllowances = $"{BaseUrl}/odata/MasterAllowances";
    public readonly string MasterAwardDetailsClassificationCategories = $"{BaseUrl}/odata/MasterAwardDetailsClassificationCategories";
    public readonly string MasterAwardDetailsClassificationCategoryEmploymentTypes = $"{BaseUrl}/odata/MasterAwardDetailsClassificationCategoryEmploymentTypes";
    public readonly string MasterAwardDetailsClassificationRates = $"{BaseUrl}/odata/MasterAwardDetailsClassificationRates";
    public readonly string MasterAwardDetailsClassificationSubCategories = $"{BaseUrl}/odata/MasterAwardDetailsClassificationSubCategories";
    public readonly string MasterAwardDetailsClassifications = $"{BaseUrl}/odata/MasterAwardDetailsClassifications";
    public readonly string MasterAwardDetailsOvertimeStates = $"{BaseUrl}/odata/MasterAwardDetailsOvertimeStates";
    public readonly string MasterAwardDetailsStates = $"{BaseUrl}/odata/MasterAwardDetailsStates";
    public readonly string MasterAwardDetails = $"{BaseUrl}/odata/MasterAwardDetails";
    public readonly string MasterAwardEmploymentTypes = $"{BaseUrl}/odata/MasterAwardEmploymentTypes";
    public readonly string MasterAwards = $"{BaseUrl}/odata/MasterAwards";
    public readonly string MasterBreaks = $"{BaseUrl}/odata/MasterBreaks";
    public readonly string MasterCallPurposes = $"{BaseUrl}/odata/MasterCallPurposes";
    public readonly string MasterCallTypes = $"{BaseUrl}/odata/MasterCallTypes";
    public readonly string MasterClassificationInfo = $"{BaseUrl}/odata/MasterClassificationInfo";
    public readonly string MasterControls = $"{BaseUrl}/odata/MasterControls";
    public readonly string MasterDeductionPayCategories = $"{BaseUrl}/odata/MasterDeductionPayCategories";
    public readonly string MasterEmailTemplates = $"{BaseUrl}/odata/MasterEmailTemplates";
    public readonly string MasterEntitlements = $"{BaseUrl}/odata/MasterEntitlements";
    public readonly string MasterExpensePayCategories = $"{BaseUrl}/odata/MasterExpensePayCategories";
    public readonly string MasterExpensePayCategoryAwardDetailsClassifications = $"{BaseUrl}/odata/MasterExpensePayCategoryAwardDetailsClassifications";
    public readonly string MasterExpensePayCategoryBreaks = $"{BaseUrl}/odata/MasterExpensePayCategoryBreaks";
    public readonly string MasterExpensePayCategoryOvertimes = $"{BaseUrl}/odata/MasterExpensePayCategoryOvertimes";
    public readonly string MasterExternalStatuses = $"{BaseUrl}/odata/MasterExternalStatuses";
    public readonly string MasterExternalStatusTypes = $"{BaseUrl}/odata/MasterExternalStatusTypes";
    public readonly string MasterFiscalPeriods = $"{BaseUrl}/odata/MasterFiscalPeriods";
    public readonly string MasterFiscalYears = $"{BaseUrl}/odata/MasterFiscalYears";
    public readonly string MasterGroupTypes = $"{BaseUrl}/odata/MasterGroupTypes";
    public readonly string MasterJobCycleTypes = $"{BaseUrl}/odata/MasterJobCycleTypes";
    public readonly string MasterJobTypes = $"{BaseUrl}/odata/MasterJobTypes";
    public readonly string MasterLeaveTypes = $"{BaseUrl}/odata/MasterLeaveTypes";
    public readonly string MasterNoteTypeCategories = $"{BaseUrl}/odata/MasterNoteTypeCategories";
    public readonly string MasterNoteTypes = $"{BaseUrl}/odata/MasterNoteTypes";
    public readonly string MasterOpportunityTypes = $"{BaseUrl}/odata/MasterOpportunityTypes";
    public readonly string MasterOvertimes = $"{BaseUrl}/odata/MasterOvertimes";
    public readonly string MasterPayCycles = $"{BaseUrl}/odata/MasterPayCycles";
    public readonly string MasterPayPeriodHeaders = $"{BaseUrl}/odata/MasterPayPeriodHeaders";
    public readonly string MasterPayPeriods = $"{BaseUrl}/odata/MasterPayPeriods";
    public readonly string MasterPayrollTaxes = $"{BaseUrl}/odata/MasterPayrollTaxes";
    public readonly string MasterPayrollTaxHeaders = $"{BaseUrl}/odata/MasterPayrollTaxHeaders";
    public readonly string MasterPayrollYearPeriods = $"{BaseUrl}/odata/MasterPayrollYearPeriods";
    public readonly string MasterPayrollYears = $"{BaseUrl}/odata/MasterPayrollYears";
    public readonly string MasterPriorities = $"{BaseUrl}/odata/MasterPriorities";
    public readonly string MasterPushNotificationTemplates = $"{BaseUrl}/odata/MasterPushNotificationTemplates";
    public readonly string Modules = $"{BaseUrl}/odata/Modules";
    public readonly string MedicareExemptions = $"{BaseUrl}/odata/MedicareExemptions";
    public readonly string MasterWagePayCategories = $"{BaseUrl}/odata/MasterWagePayCategories";
    public readonly string MasterVaccines = $"{BaseUrl}/odata/MasterVaccines";
    public readonly string MasterVaccinationTypes = $"{BaseUrl}/odata/MasterVaccinationTypes";
    public readonly string MasterTemplateVariables = $"{BaseUrl}/odata/MasterTemplateVariables";
    public readonly string MasterTags = $"{BaseUrl}/odata/MasterTags";
    public readonly string MasterSystemTableList = $"{BaseUrl}/odata/MasterSystemTableList";
    public readonly string MasterSystemDefinedVariables = $"{BaseUrl}/odata/MasterSystemDefinedVariables";
    public readonly string MasterSuperPayCategoryAwardDetailsClassifications = $"{BaseUrl}/odata/MasterSuperPayCategoryAwardDetailsClassifications";
    public readonly string MasterSuperAnnuationPayCategories = $"{BaseUrl}/odata/MasterSuperAnnuationPayCategories";
    public readonly string MasterStatusWebUiObjects = $"{BaseUrl}/odata/MasterStatusWebUiObjects";
    public readonly string MasterStatusTypes = $"{BaseUrl}/odata/MasterStatusTypes";
    public readonly string MasterStatusTags = $"{BaseUrl}/odata/MasterStatusTags";
    public readonly string MasterStatusPermissions = $"{BaseUrl}/odata/MasterStatusPermissions";
    public readonly string MasterStatuses = $"{BaseUrl}/odata/MasterStatuses";
    public readonly string MasterStages = $"{BaseUrl}/odata/MasterStages";
    public readonly string MasterSmsTemplates = $"{BaseUrl}/odata/MasterSmsTemplates";
    public readonly string MasterShiftAllowances = $"{BaseUrl}/odata/MasterShiftAllowances";
    public readonly string MasterShiftBreaks = $"{BaseUrl}/odata/MasterShiftBreaks";
    public readonly string MasterShiftOvertimes = $"{BaseUrl}/odata/MasterShiftOvertimes";
    public readonly string MasterShifts = $"{BaseUrl}/odata/MasterShifts";
    public readonly string MasterShiftTimes = $"{BaseUrl}/odata/MasterShiftTimes";
    
    public readonly string AwardsClassificationInfo = $"{BaseUrl}/odata/ClassificationInfo";
    public readonly string AwardDetails = $"{BaseUrl}/odata/AwardDetails";
    public readonly string Shifts = $"{BaseUrl}/odata/Shifts";
    public readonly string WagePayCategories = $"{BaseUrl}/odata/WagePayCategories";
    public readonly string Allowances = $"{BaseUrl}/odata/Allowances";
    public readonly string UnitTypes = $"{BaseUrl}/odata/UnitTypes";
    public readonly string Overtimes = $"{BaseUrl}/odata/Overtimes";
    public readonly string ShiftAllowances = $"{BaseUrl}/odata/ShiftAllowances";
    public readonly string ShiftOvertimes = $"{BaseUrl}/odata/ShiftOvertimes";
    public readonly string ShiftBreaks = $"{BaseUrl}/odata/ShiftBreaks";

    public readonly string RatesSettings = $"{BaseUrl}/odata/RatesSettings";


    public readonly string Timesheets = $"{BaseUrl}/odata/v2/Timesheets";
    public readonly string JobContacts = $"{BaseUrl}/odata/v2/JobContacts";
    public readonly string JobTypes = $"{BaseUrl}/odata/v2/JobTypes";
    public readonly string JobAwardDetailsClassifications = $"{BaseUrl}/odata/v2/JobAwardDetailsClassifications";
}
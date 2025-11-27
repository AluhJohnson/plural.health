namespace plural.health.Infrastructure.Util
{
    public enum AppointmentStatus
    {
        SEEN_DOCTOR = 1,
        AWAITING_VITALS = 2,
        ARRIVED = 3,
        NOTARRIVED = 3,
        AWAITING_DOCTOR = 4,
        ADMITTED_TO_WARD = 5,
        TRANSFERED_TO_AE = 6
    }
}

using TestTAL.Models;

namespace TestTAL.Api.Models
{
    public static class MapperExtensions
    {
        public static Occupation ToOccupation(this DA.Occupation occupation)
        {
            if (occupation != null)
            {
                Occupation occupationModel = new Occupation()
                {
                    OccupationID = occupation.OccupationId,
                    Name = occupation.Name,
                    OccupationfactorID = occupation.OccupationFactorId
                };
                return occupationModel;
            }

            return new Occupation();
        }

        public static OccupationFactor ToOccupationFactor(this DA.OccupationFactor occupationFactor)
        {
            if (occupationFactor != null)
            {
                OccupationFactor occupationFactorModel = new OccupationFactor()
                {
                    Factor = occupationFactor.Factor,
                    Name = occupationFactor.Name,
                    OccupationFactorID = occupationFactor.OccupationFactorId
                };
                return occupationFactorModel;
            }

            return new OccupationFactor();
        }
    }
}

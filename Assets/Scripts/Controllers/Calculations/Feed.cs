public class Feed
{
    public double ContactAngle, Fraction, Grade;

    /// <summary>
    /// Density in g/m^3
    /// </summary>
    public double Density;

    public double CheckContactAngle(double pd) {
        return ContactAngle;
    }

    public double ContactAngleDistribution(double dblParticleDiam)
    {
       if (dblParticleDiam < 0.000015d)
       {
            return ContactAngle;
       }
       else if (dblParticleDiam < 0.000025d)
       {
           return ContactAngle * ((0.000025 - dblParticleDiam) / 0.00001);
       }
        // interpolates contact angle between entered values

        else if (dblParticleDiam < 0.000038d)
        {
            return ContactAngle * ((0.000038 - dblParticleDiam) / 0.000013);
        }
        else if (dblParticleDiam < 0.000045d)
        {
            return ContactAngle * ((0.000045 - dblParticleDiam) / 0.000007);
        }
        else if (dblParticleDiam < 0.000075d)
        {
             return ContactAngle * ((0.000075 - dblParticleDiam) / 0.00003);
        }
        else if (dblParticleDiam < 0.000106d)
        {
            return ContactAngle * ((0.000106 - dblParticleDiam) / 0.000031);
        }
        else if (dblParticleDiam < 0.00015d)
        {
            return ContactAngle * ((0.00015 - dblParticleDiam) / 0.000044);

        }
        else if (dblParticleDiam < 0.00018d)
        {
            return ContactAngle * ((0.00018 - dblParticleDiam) / 0.00003);
        }
        else if (dblParticleDiam < 0.00025d)
        {
            return ContactAngle * ((0.00025 - dblParticleDiam) / 0.00007);
        }
        else if (dblParticleDiam < 0.000425d)
        {
            return ContactAngle * ((0.000425 - dblParticleDiam) / 0.000175);
        }
        if (ContactAngle >= 88.7d)
        {
            return 88.7d;
        }
        else
        {
            return 0d;
        }       
    }



}

public class Reagent
{
    public double Gamma; //MolPerm2
    public double K;//M^-1
    public double Conversor; //From PPM to mol/L

    public Reagent(double gamma, double k, double conversor) {
        Gamma = gamma;
        K = k;
        Conversor = conversor;
    }
}
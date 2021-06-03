using Rettsjekk_Register.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rettsjekk_Register.Data
{
    public interface ICourtCheck
    {
        List<Trials.Trial> TrialsSearch(string vatnum, string date);
        List<Trials.Bankruptcy> BankruptcySearch(string vatnum);
        List<Trials.Solvent> SolventSearch(string vatnum);
        void GetToken();


    }
}

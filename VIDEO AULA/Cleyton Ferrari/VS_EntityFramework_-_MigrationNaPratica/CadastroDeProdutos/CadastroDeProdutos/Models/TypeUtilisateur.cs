using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TP.Models.DataModels
{
    public enum TypeUtilisateur
    {
        [Description("Administrateur")]
        Administrateur,
        [Description("Membre")]
        Membre
    }
}
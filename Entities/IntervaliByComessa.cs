using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartB.API.Entities
{
    public class IntervaliByCommessa
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the commessa.</summary>
        ///
        /// <value>The commessa.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Commessa { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the intervali by article.</summary>
        ///
        /// <value>The intervali by article.</value>
        ///-------------------------------------------------------------------------------------------------

        public IEnumerable<IntervaliByArticle> IntervaliByArticle { get; set; }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>An intervali by article.</summary>
    ///
    /// <remarks>Software Developer Aleksandar Vučković - Aerre Romania, 07/05/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    public class IntervaliByArticle
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the article.</summary>
        ///
        /// <value>The article.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Article { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the intervali by phase.</summary>
        ///
        /// <value>The intervali by phase.</value>
        ///-------------------------------------------------------------------------------------------------

        public IEnumerable<IntervaliByPhase> IntervaliByPhase { get; set; }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>An intervali by phase.</summary>
    ///
    /// <remarks>Software Developer Aleksandar Vučković - Aerre Romania, 07/05/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    public class IntervaliByPhase
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the phase.</summary>
        ///
        /// <value>The phase.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Phase { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets information describing the employee.</summary>
        ///
        /// <value>Information describing the employee.</value>
        ///-------------------------------------------------------------------------------------------------

        public IEnumerable<IntervaliData> EmployeeData { get; set; }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>An intervali data.</summary>
    ///
    /// <remarks>Software Developer Aleksandar Vučković - Aerre Romania, 07/05/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    public class IntervaliData
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the line.</summary>
        ///
        /// <value>The line.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Line { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the name.</summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the commessa.</summary>
        ///
        /// <value>The commessa.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Commessa { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the article.</summary>
        ///
        /// <value>The article.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Article { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the phase.</summary>
        ///
        /// <value>The phase.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Phase { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the article phase.</summary>
        ///
        /// <value>The article phase.</value>
        ///-------------------------------------------------------------------------------------------------

        public int ArticlePhase { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the normalize.</summary>
        ///
        /// <value>The normalize.</value>
        ///-------------------------------------------------------------------------------------------------

        public double Norm { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the h 7.</summary>
        ///
        /// <value>The h 7.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H7 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the h 8.</summary>
        ///
        /// <value>The h 8.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H8 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the h 9.</summary>
        ///
        /// <value>The h 9.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H9 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 10.</summary>
        ///
        /// <value>The h 10.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H10 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 11.</summary>
        ///
        /// <value>The h 11.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H11 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 12.</summary>
        ///
        /// <value>The h 12.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H12 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 13.</summary>
        ///
        /// <value>The h 13.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H13 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 14.</summary>
        ///
        /// <value>The h 14.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H14 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 15.</summary>
        ///
        /// <value>The h 15.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H15 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 16.</summary>
        ///
        /// <value>The h 16.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H16 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 17.</summary>
        ///
        /// <value>The h 17.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H17 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 18.</summary>
        ///
        /// <value>The h 18.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H18 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 19.</summary>
        ///
        /// <value>The h 19.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H19 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 20.</summary>
        ///
        /// <value>The h 20.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H20 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 21.</summary>
        ///
        /// <value>The h 21.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H21 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the 22.</summary>
        ///
        /// <value>The h 22.</value>
        ///-------------------------------------------------------------------------------------------------

        public int H22 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the total number of first.</summary>
        ///
        /// <value>The total number of first.</value>
        ///-------------------------------------------------------------------------------------------------

        public int TotalFirst { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the total number of second.</summary>
        ///
        /// <value>The total number of second.</value>
        ///-------------------------------------------------------------------------------------------------

        public int TotalSecond { get; set; }

        public int H7Duration { get; set; }

        public int H8Duration { get; set; }

        public int H9Duration { get; set; }

        public int H10Duration { get; set; }

        public int H11Duration { get; set; }

        public int H12Duration { get; set; }

        public int H13Duration { get; set; }

        public int H14Duration { get; set; }

        public int H15Duration { get; set; }

        public int H16Duration { get; set; }

        public int H17Duration { get; set; }

        public int H18Duration { get; set; }

        public int H19Duration { get; set; }

        public int H20Duration { get; set; }

        public int H21Duration { get; set; }

        public int H22Duration { get; set; }

        public IEnumerable<DateTime> Clicks { get; set; }

        public IEnumerable<DateTime> H7Clicks { get; set; }

        public IEnumerable<DateTime> H8Clicks { get; set; }

        public IEnumerable<DateTime> H9Clicks { get; set; }

        public IEnumerable<DateTime> H10Clicks { get; set; }

        public IEnumerable<DateTime> H11Clicks { get; set; }

        public IEnumerable<DateTime> H12Clicks { get; set; }

        public IEnumerable<DateTime> H13Clicks { get; set; }

        public IEnumerable<DateTime> H14Clicks { get; set; }

        public IEnumerable<DateTime> H15Clicks { get; set; }

        public IEnumerable<DateTime> H16Clicks { get; set; }

        public IEnumerable<DateTime> H17Clicks { get; set; }

        public IEnumerable<DateTime> H18Clicks { get; set; }

        public IEnumerable<DateTime> H19Clicks { get; set; }

        public IEnumerable<DateTime> H20Clicks { get; set; }

        public IEnumerable<DateTime> H21Clicks { get; set; }

        public IEnumerable<DateTime> H22Clicks { get; set; }

        public DateTime H7Start { get; set; }

        public DateTime H7Stop { get; set; }

        public DateTime H8Start { get; set; }

        public DateTime H8Stop { get; set; }

        public DateTime H9Start { get; set; }

        public DateTime H9Stop { get; set; }

        public DateTime H10Start { get; set; }

        public DateTime H10Stop { get; set; }

        public DateTime H11Start { get; set; }

        public DateTime H11Stop { get; set; }

        public DateTime H12Start { get; set; }

        public DateTime H12Stop { get; set; }

        public DateTime H13Start { get; set; }

        public DateTime H13Stop { get; set; }

        public DateTime H14Start { get; set; }

        public DateTime H14Stop { get; set; }

        public DateTime H15Start { get; set; }

        public DateTime H15Stop { get; set; }

        public DateTime H16Start { get; set; }

        public DateTime H16Stop { get; set; }

        public DateTime H17Start { get; set; }

        public DateTime H17Stop { get; set; }

        public DateTime H18Start { get; set; }

        public DateTime H18Stop { get; set; }

        public DateTime H19Start { get; set; }

        public DateTime H19Stop { get; set; }

        public DateTime H20Start { get; set; }

        public DateTime H20Stop { get; set; }

        public DateTime H21Start { get; set; }

        public DateTime H21Stop { get; set; }

        public DateTime H22Start { get; set; }

        public DateTime H22Stop { get; set; }

        public int MediaFirst { get; set; }

        public int MediaSecond { get; set; }
    }
}

/* Title:           Vehicle Weekly Cleanliness
 * Date:            4-20-18
 * Author:          Terry Holmes
 * 
 * Description:     This is the class for vehicle cleanliness */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace WeeklyVehicleCleanliness
{
    public class WeeklyVehicleCleanlinessClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        WeeklyVehicleCleanlinessDataSet aWeeklyVehicleCleanlinessDataSet;
        WeeklyVehicleCleanlinessDataSetTableAdapters.weeklyvehiclecleanlinessTableAdapter aWeeklyVehicleCleanlinessTableAdapter;

        InsertWeeklyVehicleCleanlinessEntryTableAdapters.QueriesTableAdapter aInsertWeeklyVehicleCleanlinessTableAdapter;

        FindWeeklyVehicleCleanlinessByInspectionIDDataSet aFindWeeklyVehicleCleanlinessByInspectionIDDataSet;
        FindWeeklyVehicleCleanlinessByInspectionIDDataSetTableAdapters.FindWeeklyVehicleCleanlinessByInspectionIDTableAdapter aFindWeeklyVehicleCleanlinessByInspectionIDTableAdapter;

        public FindWeeklyVehicleCleanlinessByInspectionIDDataSet FindWeeklyVehicleCleanlinessbyInspectionID(int intInspectionID)
        {
            try
            {
                aFindWeeklyVehicleCleanlinessByInspectionIDDataSet = new FindWeeklyVehicleCleanlinessByInspectionIDDataSet();
                aFindWeeklyVehicleCleanlinessByInspectionIDTableAdapter = new FindWeeklyVehicleCleanlinessByInspectionIDDataSetTableAdapters.FindWeeklyVehicleCleanlinessByInspectionIDTableAdapter();
                aFindWeeklyVehicleCleanlinessByInspectionIDTableAdapter.Fill(aFindWeeklyVehicleCleanlinessByInspectionIDDataSet.FindWeeklyVehicleCleanlinessByInspectionID, intInspectionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Weekly Vehicle Cleanliness Class // Find Weekly Vehicle Cleanliness By Inspection ID " + Ex.Message);
            }

            return aFindWeeklyVehicleCleanlinessByInspectionIDDataSet;
        }
        public bool InsertWeeklyVehicleCleanliness(int intInspectionID, int intVehicleID, bool blnVehicleCleanliness, string strCleanlinessNotes)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWeeklyVehicleCleanlinessTableAdapter = new InsertWeeklyVehicleCleanlinessEntryTableAdapters.QueriesTableAdapter();
                aInsertWeeklyVehicleCleanlinessTableAdapter.InsertWeeklyVehicleCleanliness(intInspectionID, intVehicleID, blnVehicleCleanliness, strCleanlinessNotes, DateTime.Now);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Weekly Vehicle Cleanliness Class // Insert Weekly Cleanliness Class " + Ex.Message);
            }

            return blnFatalError;
        }
        public WeeklyVehicleCleanlinessDataSet GetWeeklyVehicleCleanlinessInfo()
        {
            try
            {
                aWeeklyVehicleCleanlinessDataSet = new WeeklyVehicleCleanlinessDataSet();
                aWeeklyVehicleCleanlinessTableAdapter = new WeeklyVehicleCleanlinessDataSetTableAdapters.weeklyvehiclecleanlinessTableAdapter();
                aWeeklyVehicleCleanlinessTableAdapter.Fill(aWeeklyVehicleCleanlinessDataSet.weeklyvehiclecleanliness);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Weekly Vehicle Cleanliness Class // Get Weekly Vehicle Cleanliness Info " + Ex.Message);
            }

            return aWeeklyVehicleCleanlinessDataSet;
        }
        public void UpdateWeeklyVehicleCleanlinessDB(WeeklyVehicleCleanlinessDataSet aWeeklyVehicleCleanlinessDataSet)
        {
            try
            {
                aWeeklyVehicleCleanlinessTableAdapter = new WeeklyVehicleCleanlinessDataSetTableAdapters.weeklyvehiclecleanlinessTableAdapter();
                aWeeklyVehicleCleanlinessTableAdapter.Update(aWeeklyVehicleCleanlinessDataSet.weeklyvehiclecleanliness);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Weekly Vehicle Cleanliness Class // Update Weekly Vehicle Cleanliness DB " + Ex.Message);
            }
        }
    }
}

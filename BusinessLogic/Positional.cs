﻿using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Positional
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        
        public static int Count()
        {
            try
            {
                return DataAccessLayer.Positional.CountPositional();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting positionals");
                throw;
            }
        }

        public static List<LegaGladio.Entities.Positional> List()
        {
            try
            {
                return DataAccessLayer.Positional.ListPositional();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing positionals");
                throw;
            }
        }

        public static List<LegaGladio.Entities.Positional> ListByRace(int raceId)
        {
            try
            {
                return DataAccessLayer.Positional.ListPositionalByRace(raceId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing positionals for race " + raceId);
                throw;
            }
        }

        public static LegaGladio.Entities.Positional Get(int id)
        {
            try
            {
                return DataAccessLayer.Positional.GetPositional(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting positionals");
                throw;
            }
        }

        public static Boolean NewPositional(LegaGladio.Entities.Positional positional)
        {
            try
            {
                return DataAccessLayer.Positional.NewPositional(positional);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating positionals");
                throw;
            }
        }

        public static Boolean UpdatePositional(LegaGladio.Entities.Positional positional, int oldId)
        {
            try
            {
                return DataAccessLayer.Positional.UpdatePositional(positional, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating positionals");
                throw;
            }
        }

        public static Boolean DeletePositional(int id)
        {
            try
            {
                return DataAccessLayer.Positional.DeletePositional(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting positionals");
                throw;
            }
        }
    }
}

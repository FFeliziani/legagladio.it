﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using LegaGladio.Models;
using League = LegaGladio.Entities.League;
using Series = LegaGladio.Entities.Series;

namespace LegaGladio.Controllers
{
    public class SeriesController : ApiController
    {
        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public Series Get(int id)
        {
            return BusinessLogic.Series.Get(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByLeague")]
        public ICollection<Series> GetByLeague(int id)
        {
            var league = new League { Id = id };
            return BusinessLogic.Series.List(league);
        }

        [HttpPost]
        [ActionName("addSeriesToLeague")]
        [AcceptVerbs("POST")]
        public void AddSeriesToLeague([FromUri]String token, [FromBody]AddItemsData addItemsData)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Series.AddSeriesToLeague(Convert.ToInt32(addItemsData.Id2), Convert.ToInt32(addItemsData.Id1));
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        [HttpPost]
        [ActionName("removeSeriesFromLeague")]
        [AcceptVerbs("POST")]
        public void RemoveSeriesFromLeague([FromUri]String token, [FromBody]AddItemsData addItemsData)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Series.RemoveSeriesFromLeague(Convert.ToInt32(addItemsData.Id2), Convert.ToInt32(addItemsData.Id1));
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // POST api/player
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]Series data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Series.NewSeries(data);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // PUT api/player/5
        [HttpPut]
        [ActionName("put")]
        [AcceptVerbs("PUT")]
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Series data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Series.UpdateSeries(data, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/player/5
        [HttpDelete]
        [ActionName("delete")]
        [AcceptVerbs("DELETE")]
        public void Delete([FromUri]String token, [FromUri]int id)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Series.DeleteSeries(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}

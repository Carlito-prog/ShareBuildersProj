using Microsoft.EntityFrameworkCore;
using ShareBuilderProj.Data;
using ShareBuilderProj.Data.Models;

namespace ShareBuilderProj.Services
{
	public class StationService
	{
		private IDbContextFactory<StationDbContext> _dbContextFactory;


		public StationService(IDbContextFactory<StationDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
        }

		public List<StationModel> GetStations()
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{
				List<StationModel> stations = context.Stations.ToList();
				return stations;
			}

        }
		public void AddUser(UserModel user)
		{
			if (user.Equals(null))
			{

				throw new Exception(" Enter a User");

            } else
			{
				using (var context = _dbContextFactory.CreateDbContext())
				{
					context.Users.Add(user);
					context.SaveChanges();
				}
			}

		}
		public void DeleteUser(int UserId, int StationId)
		{
            using (var context = _dbContextFactory.CreateDbContext())
			{
				var station = context.Stations.Single(x => x.Id == StationId);
				var user = context.Users.Where(x => EF.Property<int>(x, station.Id.ToString()) == UserId);
                context.SaveChanges();
            }

        }
	}
}


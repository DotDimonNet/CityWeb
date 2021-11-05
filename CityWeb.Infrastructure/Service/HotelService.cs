using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Interfaces.Service;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CityWeb.Infrastructure.Service
{
    public class HotelService : IHotelService
    {
        private readonly HotelBuilderResult _builderResult;
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HotelService> _logger;

        public HotelService(ApplicationContext context, IMapper mapper, ILogger<HotelService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<RoomModel> AddRoom(RoomDTO DTO)
        {
            try
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == DTO.HotelTitle);
                if (hotel != null)
                {
                    var roomNum = await _context.Rooms.Select(x => x.Number).FirstOrDefaultAsync(x => x == DTO.Number);

                    if (roomNum != DTO.Number)
                    {
                        var room = _mapper.Map<RoomDTO, RoomModel>(DTO);
                        room.Type = await _context.Rooms.Select(x => x.Type).FirstOrDefaultAsync(x => x == DTO.Type);
                        await _context.Rooms.AddAsync(room);
                        await _context.SaveChangesAsync();
                        _logger.LogInformation($"Room {room.Number} succsesfully added to {DTO.HotelTitle} hotel.");
                        return room;
                    }
                    _logger.LogWarning($"Room {DTO.Number} in hotel {DTO.HotelTitle} already exist.");
                    throw new Exception("Room with this number already exist!");
                }
                _logger.LogWarning($"Hotel {DTO.HotelTitle} does not exist.");
                throw new Exception("Hotel does not exist!");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public async Task<RoomModel> UpdateRoom(UpdateRoomDTO DTO)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == DTO.HotelTitle);

            if (hotel != null)
            {
                var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Title == hotel.Title && x.Number == DTO.Number);

                if(room != null)
                {
                    room = _mapper.Map<UpdateRoomDTO, RoomModel>(DTO);
                    room.RentPeriod = _mapper.Map<PeriodModelDTO, PeriodModel>(DTO.RentPeriod);
                    room.Type = await _context.Rooms.Select(x => x.Type).FirstOrDefaultAsync(x => x == DTO.Type);
                    _context.Hotels.Update(hotel);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Room {room.Number} in hotel {room.Hotel.Title} succsesfully updated.");
                    return room;
                }
                _logger.LogWarning($"Room {DTO.Number} in hotel {DTO.HotelTitle} doesnt exist.");
                throw new Exception("Room with this number doesnt exist!");             
            }
            _logger.LogWarning($"Hotel with title {DTO.HotelTitle} doesnt exist.");
            throw new Exception("Hotel with this title doesnt exist!");
        }

        public async Task<bool> RemoveRoom(DeleteRoomDTO room)
        {
            var removeRoom = await _context.Rooms.FirstOrDefaultAsync(
                x => x.Hotel.Id == room.HotelId 
                    && x.Hotel.Title == room.HotelTitle 
                    && x.Number == room.RoomNumber);

            if (room != null)
            {        
                _context.Rooms.Remove(removeRoom);
                _context.Update(_context.Rooms);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Room {room.RoomNumber} in hotel {room.HotelTitle} succsesfully removed.");
                return true;
            }
            _logger.LogWarning($"Hotel {room.HotelTitle} does not exist.");
            throw new Exception("Hotel does not exist!");
        }

        public async Task<HotelModel> AddHotel(HotelDTO hotelDTO)
        {
            try 
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == hotelDTO.Title);

                if (hotel == null)
                {
                    hotel = _mapper.Map<HotelDTO, HotelModel>(hotelDTO);
                    hotel.Service = new ServiceModel();
                    await _context.Hotels.AddAsync(hotel);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Hotel {hotel.Title} succsesfully added.");
                    return hotel;
                }
                _logger.LogWarning($"Hotel {hotel.Title} already exist.");
                throw new Exception("Hotel with this title already exist!");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<HotelModel> UpdateHotel(HotelDTO DTO)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == DTO.Title);

            if (hotel != null)
            {
                hotel = _mapper.Map<HotelModel>(DTO);
                _context.Hotels.Update(hotel);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Hotel {hotel.Title} succsesfully updated.");
                return hotel;
            }
            _logger.LogWarning($"Hotel {DTO.Title} doesnt exist.");
            throw new Exception("Hotel with this title doesnt exist!");          
        }
        public async Task<bool> RemoveHotel(DeleteHotelDTO hotelDTO)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == hotelDTO.HotelTitle);

            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return true;
            }
            throw new Exception("Hotel with this title doesnt exist!");
        }
        public async Task<HotelModel> FindHotelById(HotelIdDTO DTO)
        {
            var res = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == DTO.Id);

            if(res != null)
            {
                return res;
            }    
            throw new Exception("Hotel with this ID doesnt exist!");     
        }

        public async Task<HotelModel> FindHotelByTitle(HotelTitleDTO DTO)
        {
            var res = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == DTO.Title);

            if (res != null)
            {
                return res;
            }
            throw new Exception("Hotel with this title doesnt exist!");         
        }
        public async Task<List<HotelRoomType>> GetAllRoomTypesByHotelTitle(HotelTitleDTO DTO)
        {
            var res = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == DTO.Title);

            if (res != null)
            {
                return await _context.Rooms.Where(x => x.Hotel.Title == DTO.Title).Select(x => x.Type).Distinct().ToListAsync();
            }
            throw new Exception("Hotel with this title doesnt exist!");          
        }
        public async Task<IEnumerable<HotelDTO>> GetAllHotels()
        {
            return await _context.Hotels.Select(x => _mapper.Map<HotelModel, HotelDTO>(x)).ToListAsync();
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            return await _context.Rooms.Select(x => _mapper.Map<RoomModel, RoomDTO>(x)).ToListAsync();
        }

        //Step 1
        public async Task<ICollection<RoomModel>> GetAllFreeRooms(HotelTitleDTO DTO)
        {
            _builderResult.HotelTitle = DTO.Title;
            return await _context.Rooms.Where(x => x.Hotel.Title == DTO.Title && x.IsFree).ToListAsync();
        }
        //Step 2
        public async Task<RoomModel> GetSelectedRoom(int roomNum)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Title == _builderResult.HotelTitle && x.Number == roomNum);
            _builderResult.RoomNumber = roomNum;
            _builderResult.RoomType = room.Type;
            _builderResult.Image = room.Image;
            return room;
        }
        //Final step
        public async Task<HotelBuilderResult> GetHotelResult(DateTime starDate, DateTime endDate)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Title == _builderResult.HotelTitle && x.Number == _builderResult.RoomNumber);
            _builderResult.StartDate = starDate;
            _builderResult.EndDate = endDate;
            _builderResult.DaysAmount = (endDate - starDate).Days;
            //HotelPayment(room.Price,_builderResult.DaysAmount ); //Not realised yet.
            _builderResult.TotalPrice = room.Price.Total;
            return _builderResult;
        }


        public async Task<HotelBuilderResult> StepOne(string hotelTitle)
        {
            var result =  new HotelBuilderResult();
            result.HotelTitle = hotelTitle;
            var roomTypes = await _context.Rooms.Where(x => x.Hotel.Title == result.HotelTitle ).Select(x => x.Type).Distinct().ToListAsync();
            return result;
        }
        public async Task<HotelBuilderResult> StepTwo(HotelBuilderResult result, HotelRoomType type)
        {
            result.RoomType = type;
            var rooms = _context.Rooms.Where(x => x.Hotel.Title == result.HotelTitle && x.IsFree && x.Type == result.RoomType);    
            return result;
        }
        public async Task<HotelBuilderResult> StepThree(HotelBuilderResult result, int roomNum)
        {
            result.RoomNumber = roomNum ;
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Title == result.HotelTitle && x.Number == result.RoomNumber);
            result.TotalPrice = room.Price.Total;
            return result;
        }

    }
}

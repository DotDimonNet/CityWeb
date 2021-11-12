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

        public async Task<RoomDTO> AddRoom(RoomDTO model)
        {
            try
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == model.HotelTitle);
                if (hotel != null)
                {
                    var roomNum = await _context.Rooms.FirstOrDefaultAsync(x => x.Number == model.Number);

                        if (roomNum.Number != model.Number)
                    {
                        var room = _mapper.Map<RoomDTO, RoomModel>(model);
                        room.HotelId = hotel.Id;
                        await _context.Rooms.AddAsync(room);
                        await _context.SaveChangesAsync();
                        _logger.LogInformation($"Room {room.Number} succsesfully added to {model.HotelTitle} hotel.");
                        return _mapper.Map<RoomModel, RoomDTO>(room);
                    }
                    throw new Exception($"Room {model.Number} in hotel {model.HotelTitle} already exist.");
                }
                throw new Exception($"Hotel {model.HotelTitle} does not exist.");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateRoomDTO> UpdateRoom(UpdateRoomDTO model)
        {
            try
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == model.HotelTitle);

                if (hotel != null)
                {
                    var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Title == hotel.Title && x.Number == model.Number);

                    if (room != null)
                    {
                        _mapper.Map<UpdateRoomDTO, RoomModel>(model, room);
                        _context.Hotels.Update(hotel);
                        await _context.SaveChangesAsync();
                        _logger.LogInformation($"Room {room.Number} in hotel {room.Hotel.Title} succsesfully updated.");
                        return _mapper.Map<RoomModel, UpdateRoomDTO>(room); 
                    }
                    throw new Exception($"Room {model.Number} in hotel {model.HotelTitle} doesnt exist.");
                }
                throw new Exception($"Hotel with title {model.HotelTitle} doesnt exist.");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<bool> RemoveRoom(DeleteRoomDTO room)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }           
        }

        public async Task<HotelDTO> AddHotel(HotelDTO hotelDTO)
        {
            try 
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == hotelDTO.Title);

                if(hotel == null)
                {
                    hotel = _mapper.Map<HotelDTO, HotelModel>(hotelDTO);
                    hotel.Service = new ServiceModel();
                    await _context.Hotels.AddAsync(hotel);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Hotel {hotel.Title} succsesfully added.");
                    return _mapper.Map<HotelModel,HotelDTO>(hotel);
                }
                throw new Exception($"Hotel {hotel.Title} already exist.");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateHotelDTO> UpdateHotel(UpdateHotelDTO model)
        {
            try
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == model.Id);

                if (hotel != null)
                {
                    _mapper.Map<UpdateHotelDTO,HotelModel>(model,hotel);
                    _context.Hotels.Update(hotel);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Hotel {hotel.Title} succsesfully updated.");
                    return _mapper.Map< HotelModel, UpdateHotelDTO>( hotel);
                }
                throw new Exception($"Hotel {model.Title} doesnt exist.");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }           
        }
                    
        public async Task<bool> RemoveHotel(HotelIdDTO model)
        {
            try
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == model.Id);

                if (hotel != null)
                {
                    _context.Hotels.Remove(hotel);
                    await _context.SaveChangesAsync();
                    return true;
                }
                throw new Exception($"Hotel with this ID doesnt exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }            
        }

        public async Task<HotelModel> FindHotelById(HotelIdDTO model)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.Id == model.Id);
        }

        public async Task<HotelModel> FindHotelByTitle(HotelTitleDTO model)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.Title == model.Title);
        }
        public async Task<List<HotelRoomType>> GetAllRoomTypesByHotelTitle(HotelTitleDTO model)
        {
            var res = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == model.Title);

            if (res != null)
            {
                return await _context.Rooms.Where(x => x.Hotel.Title == model.Title).Select(x => x.Type).Distinct().ToListAsync();
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
        public async Task<ICollection<RoomModel>> GetAllFreeRooms(HotelTitleDTO model)
        {
            _builderResult.HotelTitle = model.Title;
            return await _context.Rooms.Where(x => x.Hotel.Title == model.Title && x.IsFree).ToListAsync();
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
    }
}

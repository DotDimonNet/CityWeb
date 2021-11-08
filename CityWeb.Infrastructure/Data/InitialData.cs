using CityWeb.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityWeb.Infrastucture.Data
{
    public static class InitialData
    {
        public static void SetupEnums(ApplicationContext _context)
        {
            if (!_context.PaymentStatuses.Any())
            {
                _context.AddRange(
                    PaymentStatus.Accepted,
                    PaymentStatus.Approved,
                    PaymentStatus.Created,
                    PaymentStatus.Discarded,
                    PaymentStatus.Executed,
                    PaymentStatus.Refunded,
                    PaymentStatus.Removed
                    );

                _context.SaveChanges();
            }

            /*if (!_context.TransportTypes.Any())
            {
                _context.AddRange(
                    TransportType.Econom,
                    TransportType.Standart,
                    TransportType.Business);

                _context.SaveChanges();
            }*/

            //if (!_context.EventTypes.Any())
            //{
            //    _context.AddRange(
            //        EntertainmentType.Cinema,
            //        EntertainmentType.Circus,
            //        EntertainmentType.Club,
            //        EntertainmentType.Exhibition,
            //        EntertainmentType.Fest,
            //        EntertainmentType.Museum,
            //        EntertainmentType.Theatre
            //        );

            //    _context.SaveChanges();
            //}

            /*if (!_context.HouseBillType.Any())
            {
                _context.AddRange(
                    HouseBillType.Electricity,
                    HouseBillType.WaterGet,
                    HouseBillType.WaterOut,
                    HouseBillType.Gas,
                    HouseBillType.GasTransport,
                    HouseBillType.Intercom,
                    HouseBillType.Internet,
                    HouseBillType.TV,
                    HouseBillType.Trash,
                    HouseBillType.Rent);

                _context.SaveChanges();
            }*/
        }

        public static void SetupData(ApplicationContext _context)
        {
            /*
             var taxiUber = new TaxiModel()
            {
                Title = "Uber",
                Description = "Uncommon taxi",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Vehicle =
                {
                    new TaxiCarModel()
                    {
                        Mark = "Nissan",
                        IsFree = false,
                        Color = "blue",
                        Seats = 7,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Type = Domain.Enums.TransportType.TaxiStandart,
                        StartAddress = new AddressModel()
                        {
                            StreetName = "Porika",
                            HouseNumber = "31"
                        },
                        DestinationAddresses =
                        {
                            new AddressModel()
                            {
                                StreetName = "Soborna",
                                HouseNumber = "24"
                            },
                            new AddressModel()
                            {
                                StreetName = "Kyivska",
                                HouseNumber = "5"
                            }
                        },
                        Price = new PriceModel()
                        {
                            Value = 50
                        },
                        Number = "AB 8948 XA",
                        //Payment = new PaymentModel()
                        //{
                        //    Price = new PriceModel()
                        //    {
                        //        Value = 65
                        //    }
                        //},
                        JourneyPeriod = new PeriodModel()
                        {
                            StartTime = DateTime.Now,
                            EndTime = DateTime.Now.AddHours(1)
                        }
                    },
                    new TaxiCarModel()
                    {
                        Mark = "Audi",
                        IsFree = true,
                        Color = "red",
                        Seats = 2,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Type = Domain.Enums.TransportType.TaxiStandart,
                        StartAddress = new AddressModel()
                        {
                            StreetName = "Yangelya",
                            HouseNumber = "15"
                        },
                        DestinationAddresses =
                        {
                            new AddressModel()
                            {
                                StreetName = "Soborna",
                                HouseNumber = "24"
                            },
                        },
                        Price = new PriceModel()
                        {
                            Value = 70
                        },
                        Number = "AB 4988 BA",
                        Payment = new PaymentModel()
                        {
                            //Price = new PriceModel()
                            //{
                            //    Value = 100
                            //}
                        },
                        JourneyPeriod = new PeriodModel()
                        {

                        }
                    },

                },
            };
            var taxi888 = new TaxiModel()
            {
                Title = "888",
                Description = "Common taxi",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Vehicle =
                {
                    new TaxiCarModel()
                    {
                        Mark = "Ford",
                        IsFree = true,
                        Color = "brown",
                        Seats = 4,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Type = Domain.Enums.TransportType.TaxiEconom,
                        StartAddress = new AddressModel()
                        {
                            StreetName = "Keletska",
                            HouseNumber = "55"
                        },
                        DestinationAddresses =
                        {
                            new AddressModel()
                            {
                                StreetName = "Soborna",
                                HouseNumber = "24"
                            },
                            new AddressModel()
                            {
                                StreetName = "Yangelya",
                                HouseNumber = "15"
                            }
                        },
                        Price = new PriceModel()
                        {
                            Value = 20
                        },
                        Number = "AB 5162 BS",
                    },
                },
                Payments = new PaymentModel()
                {
                    //Price = new PriceModel()
                    //{
                    //    Value = 25
                    //}                    
                }
            };
            var zipcar = new CarSharingModel()
            {
                Title = "Zipcar",
                Description = "Rent Car Company",
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Location = new AddressModel()
                {

                    StreetName = "Soborna",
                    HouseNumber = "25A",
                    Id = Guid.NewGuid()
                },
                Vehicle = {
                    
                        new RentCarModel()
                        {
                            Id = Guid.NewGuid(),
                            Mark = "Zhigalet",
                            Color = "GnilaVishnya",
                            Price = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 5
                            },
                            Type = Domain.Enums.TransportType.RentCar,
                            Number = "ASS000L",
                            Seats = 5,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            RentPeriod = {new PeriodModel()
                            {

                            } }
                        },
                        new RentCarModel()
                        {
                            Id = Guid.NewGuid(),
                            Mark = "Honda",
                            Color = "Red",
                            Price = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 500
                            },
                            Type = Domain.Enums.TransportType.RentCar,
                            Number = "AB 4532 BX",
                            Seats = 5,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            RentPeriod =
                            {
                                new PeriodModel()
                                {
                                    StartTime = new DateTime(2021,10,20),
                                    EndTime = new DateTime(2021,10,24),
                                }
                            }
                        }
                }
            };
            var rental = new CarSharingModel()
            {
                Title = "Rental",
                Description = "Rent Car Company in Vinnytsa",
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Location = new AddressModel()
                {

                    StreetName = "Kyivska",
                    HouseNumber = "11",
                    Id = Guid.NewGuid()
                },
                Vehicle =
                {
                        new RentCarModel()
                        {
                            Id = Guid.NewGuid(),
                            Mark = "BMW",
                            Color = "pink",
                            Price = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 450
                            },
                            Type = Domain.Enums.TransportType.RentCar,
                            Number = "AB 5616 X5",
                            Seats = 2,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            RentPeriod = {new PeriodModel()
                            {

                            }}
                        },
                        new RentCarModel()
                        {
                            Id = Guid.NewGuid(),
                            Mark = "Honda",
                            Color = "White",
                            Price = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 400
                            },
                            Type = Domain.Enums.TransportType.RentCar,
                            Number = "AB 9845 RT",
                            Seats = 2,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            RentPeriod = {new PeriodModel()
                            {
                                StartTime = new DateTime(2021,10,21),
                                EndTime = new DateTime(2021,10,25),
                            } },

                        }
                 }
            };
            var hotelHillton = new HotelModel()
            {
                Title = "Hillton",
                Description = "5 stars",
                RentAddress = new AddressModel()
                {
                    StreetName = "Soborna",
                    HouseNumber = "1",
                },
                Rooms =
                {
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Delux,
                         Number = 101,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 1500,

                         },

                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {

                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Delux,
                         Number = 102,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 1500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {

                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Delux,
                         Number = 104,
                         IsFree = false,
                         Price = new PriceModel()
                         {
                             Value = 1500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {
                             StartTime = new DateTime(2021,10,20),
                             EndTime = new DateTime(2021,10,24),
                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Lux,
                         Number = 201,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 1000,
                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {

                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.President,
                         Number = 606,
                         IsFree = false,
                         Price = new PriceModel()
                         {
                             Value = 3500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {
                             StartTime = new DateTime(2021,10,20),
                             EndTime = new DateTime(2021,10,27),
                        }
                    },

                },
                Created = new DateTime(1847, 12, 24),
                Modified = new DateTime(2019, 8, 13),
            };
            var hotelCalifornia = new HotelModel()
            {
                Title = "California",
                Description = "4 stars",
                RentAddress = new AddressModel()
                {
                    StreetName = "Vatytina",
                    HouseNumber = "23",
                },
                Rooms =
                {
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Standart,
                         Number = 101,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {

                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Standart,
                         Number = 102,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {

                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Standart,
                         Number = 103,
                         IsFree = false,
                         Price = new PriceModel()
                         {
                             Value = 500,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {
                             StartTime = new DateTime(2021,10,21),
                             EndTime = new DateTime(2021,10,27),
                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.Econom,
                         Number = 201,
                         IsFree = true,
                         Price = new PriceModel()
                         {
                             Value = 400,
                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {

                        }
                    },
                    new RoomModel()
                    {
                         Type = Domain.Enums.HotelRoomType.President,
                         Number = 202,
                         IsFree = false,
                         Price = new PriceModel()
                         {
                             Value = 400,

                         },
                         Created = DateTime.Now,
                         Modified = DateTime.Now,
                         RentPeriod = new PeriodModel()
                        {
                             StartTime = new DateTime(2021,10,20),
                             EndTime = new DateTime(2021,10,27),
                        }
                    },

                },
                Created = new DateTime(2015, 12, 24),
                Modified = new DateTime(2019, 8, 13),
            };
            var deliveryTorpedo = new DeliveryModel()
            {
                Title = "Torpedo",
                Description = "Food Delivery",
                WorkSchedule = new PeriodModel()
                {
                    StartTime = new DateTime(2015, 7, 20, 09, 00, 00),
                    EndTime = new DateTime(2015, 7, 20, 23, 30, 00),
                },
                Products =
                {
                    new ProductModel()
                    {
                        ProductName = "Pizza Papperoni",
                        ProductPrice = new PriceModel()
                        {
                            Value = 149.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Pizza 4Chees",
                        ProductPrice = new PriceModel()
                        {
                            Value = 119.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "UnagiMaki",
                        ProductPrice = new PriceModel()
                        {
                            Value = 79.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Burger",
                        ProductPrice = new PriceModel()
                        {
                            Value = 99.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                },
                DeliveryPrice = new PriceModel()
                {
                    Value = 25,
                },

            };
            var deliveryRocket = new DeliveryModel()
            {
                Title = "Rocket",
                Description = "Get you all",
                WorkSchedule = new PeriodModel()
                {
                    StartTime = new DateTime(2015, 7, 20, 07, 00, 00),
                    EndTime = new DateTime(2015, 7, 20, 23, 30, 00),
                },
                Products =
                {
                    new ProductModel()
                    {
                        ProductName = "Salat Cesar",
                        ProductPrice = new PriceModel()
                        {
                            Value = 79.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Steak",
                        ProductPrice = new PriceModel()
                        {
                            Value = 139.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Udon whis chiken",
                        ProductPrice = new PriceModel()
                        {
                            Value = 54.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                    new ProductModel()
                    {
                        ProductName = "Shaverma",
                        ProductPrice = new PriceModel()
                        {
                            Value = 64.99,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                    },
                },
                DeliveryPrice = new PriceModel()
                {
                    Value = 30,
                },

            };
            var housepay = new HousePayModel()
            {
                Title = "Platizh",
                Description = "oplata za internet",
                Owner = new UserProfileModel()
                {
                    Address = new AddressModel
                    {
                        StreetName = "Pravdy",
                        HouseNumber = "123",
                    },
                },
                CounterModels = {
                    new CounterModel
                        {

                         Type = Domain.Enums.HousePaymentType.Gas,

                        },
                },

                Created = DateTime.Now,
                Modified = DateTime.Now,
            };
            var cinema = new EntertainmentModel()
            {
                Title = "SmartCinema",
                Description = "Cinema",
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Address = new AddressModel()
                {

                    StreetName = "Soborna",
                    HouseNumber = "25A",
                    Id = Guid.NewGuid()
                },
                Event = 
                {
                        new EventModel()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Venom",
                            EventPrice = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 50
                            },
                            Type = Domain.Enums.EntertainmentType.Cinema,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,

                        },
                        new EventModel()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Duna",
                            EventPrice = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 50
                            },
                            Type = Domain.Enums.EntertainmentType.Cinema,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        new EventModel()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Bad Boys",
                            EventPrice = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 50
                            },
                            Type = Domain.Enums.EntertainmentType.Cinema,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        },
                        new EventModel()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Spider-Man",
                            EventPrice = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 50
                            },
                            Type = Domain.Enums.EntertainmentType.Cinema,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                        }

                }
            };
            var circus = new EntertainmentModel()
            {
                Title = "Shapito",
                Description = "Circus",
                Id = Guid.NewGuid(),
                EntertainmentType = Domain.Enums.EntertainmentType.Circus,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Address = new AddressModel()
                {

                    StreetName = "ZooStreet",
                    HouseNumber = "12",
                    Id = Guid.NewGuid()
                },
                Event =
                {
                        new EventModel()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Shapito",
                            EventPrice = new PriceModel()
                            {
                                Id = Guid.NewGuid(),
                                Value = 50
                            },
                            Type = Domain.Enums.EntertainmentType.Cinema,
                            Created = new DateTime(2021,9,1),
                            Modified = DateTime.Now,

                        },
                }
            };
            var service = new ServiceModel()
            {
                Users =
                {
                    user
                },
                HousePayments =
                {
                    housepay
                },
                Hotels =
                {
                    hotelCalifornia,
                    hotelHillton
                },
                CarSharing =
                {
                    zipcar,
                    rental
                },
                Taxi =
                {
                    taxi888,
                    taxiUber
                },
                Deliverys =
                {
                    deliveryTorpedo,
                    deliveryRocket
                },
                Entertaiments =
                {
                    cinema,
                    circus
                }
            };


            _context.Add(service);
            _context.Add(deliveryRocket);
            _context.Add(deliveryTorpedo);
            _context.Add(hotelCalifornia);
            _context.Add(hotelHillton);
            _context.Add(taxi888);
            _context.Add(taxiUber);
            _context.Add(rental);
            _context.Add(zipcar);
            _context.Add(housepay);
            _context.Add(circus);
            _context.Add(cinema);
            _context.Add(circus);
            _context.SaveChanges();
             */
        }
    }
}

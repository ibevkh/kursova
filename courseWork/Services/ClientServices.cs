﻿using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IMapper _mapper;
        private readonly JewelleryContext _db;
        public ClientServices(IMapper mapper, JewelleryContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public List<ClientDto> GetClients()
        {
            return _mapper.Map<List<ClientDto>>(_db.ClientDB.ToList());
        }

        public ClientDto AddClient(ClientDto client)
        {
            var newClient = _db.ClientDB.Add(_mapper.Map<ClientEntity>(client));
            _db.SaveChanges();
            return _mapper.Map<ClientDto>(client);
        }

    }
}
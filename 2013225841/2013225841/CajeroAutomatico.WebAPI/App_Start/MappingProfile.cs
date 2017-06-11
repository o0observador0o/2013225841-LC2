using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Entities.EntitiesDTO;


namespace CajeroAutomatico.WebAPI.App_Start
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            //CreateMap<Project, ProjectCreate>();
        }

        public MappingProfile()
        {


            CreateMap<ATM, ATMDTO>();
            CreateMap<ATMDTO, ATM>();

            CreateMap<Retiro, RetiroDTO>();
            CreateMap<RetiroDTO, Retiro>();

            CreateMap<Cuenta, CuentaDTO>();
            CreateMap<CuentaDTO, Cuenta>();

            CreateMap<Teclado, TecladoDTO>();
            CreateMap<TecladoDTO, Teclado>();

            CreateMap<RanuraDeposito, RanuraDepositoDTO>();
            CreateMap<RanuraDepositoDTO, RanuraDeposito>();

            CreateMap<Pantalla, PantallaDTO>();
            CreateMap<PantallaDTO, Pantalla>();

        }

    }
}
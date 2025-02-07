﻿using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;
using LBA_Infraestructura.Contratos;
using LBA_Negocio.Contratos;

namespace LBA_Negocio.Biblioteca
{
    public class ComandosPrueba : IComandosPrueba
    {
        private readonly IPruebaRepository _PruebaRepository;
        public ComandosPrueba(IPruebaRepository bibliotecaRepository)
        {
            _PruebaRepository = bibliotecaRepository;
        }
        public async Task<string> RegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel)
        {
            string resultado = await _PruebaRepository.RegistrarLibros(comandoRegistroViewModel);
            return resultado;
        }
        public async Task<string> ConteoVehiculos(InformacionDto informacionDto)
        {
            string resultado = await _PruebaRepository.ConteoVehiculos(informacionDto);
            return resultado;
        }
        public async Task<string> RecaudoVehiculos(InformacionDto informacionDto)
        {
            string resultado = await _PruebaRepository.RecaudoVehiculos(informacionDto);
            return resultado;
        }
    }
}

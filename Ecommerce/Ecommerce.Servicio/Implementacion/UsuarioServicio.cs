using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Modelo;
using Ecommerce.DTO;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Servicio.Contrato;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Servicio.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _modeloRepositorio;
        private readonly IMapper _mapper;
        public UsuarioServicio(IGenericoRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }


        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<SesionDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
              var dbModelo = _mapper.Map<Usuario>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdUsuario != 0)
                    return _mapper.Map<UsuarioDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear el usuario.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var consulta=_modeloRepositorio.Consultar(p=>p.IdUsuario == modelo.IdUsuario);
                var fromDbModelo = await


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Eliminar(int id)
        {
            try
            {



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDTO> Obtener(int id)
        {
            try
            {



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

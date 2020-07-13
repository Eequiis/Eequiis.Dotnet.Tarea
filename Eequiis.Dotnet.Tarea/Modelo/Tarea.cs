using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eequiis.Dotnet.Tarea
{
	/// <summary>
	/// Clase de utilidades para el manejo de acciones asíncronas con espera no bloqueante.
	/// </summary>
	public static class Tarea
	{
		/// <summary>
		/// <para>Realiza una acción después de esperar un tiempo indicado en milisegundos.</para>
		/// <para>Si la acción a realizar es nula o vacía, el método solo espera un tiempo antes de terminar
		/// sin realizar ninguna acción.</para>
		/// <para>Si el tiempo de espera es menor que cero, se lanzará una excepción de argumento fuera de rango,
		/// y solo esperará un tiempo determinado si el tiempo de espera es positivo.</para>
		/// </summary>
		/// <param name="accion">Acción a realizar diferidamente.</param>
		/// <param name="milis">Milisegundos a esperar antes de realizar la acción indicada.</param>
		/// <returns>Una tarea asíncrona que puede ser esperada con el operador await.</returns>
		public static Task Diferir(Action accion, int milis)
		{
			if (milis < 0) throw new ArgumentOutOfRangeException("Tiempo de espera negativo");

			return Task.Run(() => {
				if (milis > 0) Thread.Sleep(milis);
				if (accion != null) accion.Invoke();
			});
		}

		/// <summary>
		/// Espera no bloqueante de un tiempo (no negativo) indicado en milisegundos.
		/// </summary>
		/// <param name="milis">Tiempo de espera en milisegundos.</param>
		/// <returns>Una tarea asíncrona que puede ser esperada con el operador await.</returns>
		public static Task Espera(int milis) => Diferir(null, milis);
	}
}

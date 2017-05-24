using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MobileBDG
{
    //static T FindControlType<T>(this XRSubreport subReport, string nomeComponente) where T : class
    public static class ExtensionMethods
    {
        /// <summary>
        /// Retorna Todos os filhos de um determinado tipo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="layout"></param>
        /// <returns></returns>
        public static List<T> GetPanelChildren<T>(this Layout<Xamarin.Forms.View> layout) where T : class
        {
            List<T> children = new List<Xamarin.Forms.View>(layout.Children)
                    .FindAll(i => i is T)
                    .Select(x => x as T)
                    .ToList();

            return children;
        }

        /// <summary>
        /// Remove todas as pages de um determinado tipo
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="tipo"></param>
        public static void RemovePagesInNavigation(this INavigation navigation, Type tipo)
        {
            var pages = navigation.NavigationStack.Where(x => x.GetType() == tipo).ToList();
            foreach (var item in pages)
            {
                navigation.RemovePage(item);
            }            
        }
        /// <summary>
        /// Volta para a página home
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="pageRemove">Pagina à remover da Navigation</param>
        public static bool PushAsyncToHome(this INavigation navigation, Page pageRemove)
        {
            try
            {
                navigation.PushAsync(new Home());
                navigation.RemovePage(pageRemove);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Abre uma pagina específica e fecha a corrente
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="pageRemove"></param>
        /// <returns></returns>
        public static bool PushAsyncToPage(this INavigation navigation, Page NewPage, Page RemovePage)
        {
            try
            {
                navigation.PushAsync(NewPage);
                navigation.RemovePage(RemovePage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

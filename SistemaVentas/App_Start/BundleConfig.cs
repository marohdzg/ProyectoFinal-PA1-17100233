using System.Web;
using System.Web.Optimization;

namespace SistemaVentas
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS
           
            bundles.Add(new StyleBundle("~/Template/css").Include(
                "~/Content/vendors/select2/dist/css/select2.css",
                "~/Content/vendors/bootstrap/dist/css/bootstrap.css",
                "~/Content/vendors/font-awesome/css/font-awesome.min.css",
                "~/Content/vendors/nprogress/nprogress.css",
                "~/Content/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                "~/Content/vendors/jqvmap/dist/jqvmap.min.css",
                "~/Content/vendors/iCheck/skins/flat/green.css",
                "~/Content/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css",
                "~/Content/vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css",
                "~/Content/vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css",
                "~/Content/vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css",
                "~/Content/vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css",
                "~/Content/build/css/custom.min.css",
                "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.css",
                "~/Content/vendors/bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css",
                "~/Content/vendors/normalize-css/normalize.css",
                "~/Content/vendors/ion.rangeSlider/css/ion.rangeSlider.css",
                "~/Content/vendors/ion.rangeSlider/css/ion.rangeSlider.skinFlat.css",
                "~/Content/vendors/mjolnic-bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css",
                "~/Content/vendors/cropper/dist/cropper.min.css",
                "~/Content/vendors/iCheck/skins/flat/green.css",
                "~/Content/vendors/switchery/dist/switchery.min.css"));

            bundles.Add(new StyleBundle("~/Content/css1").Include(
          "~/Content/core.css",
          "~/Content/autocomplete.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                       "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                       "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // JS
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                        "~/Content/vendors/jquery/dist/jquery.min.js",
                        "~/Content/vendors/bootstrap/dist/js/bootstrap.min.js",
                        "~/Content/vendors/fastclick/lib/fastclick.js",
                        "~/Content/vendors/nprogress/nprogress.js",
                        "~/Content/vendors/Chart.js/dist/Chart.min.js",
                        "~/Content/vendors/gauge.js/dist/gauge.min.js",
                        "~/Content/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                        "~/Content/vendors/iCheck/icheck.min.js",
                        "~/Content/vendors/skycons/skycons.js",
                        "~/Content/vendors/Flot/jquery.flot.js",
                        "~/Content/vendors/Flot/jquery.flot.pie.js",
                        "~/Content/vendors/Flot/jquery.flot.time.js",
                        "~/Content/vendors/Flot/jquery.flot.stack.js",
                        "~/Content/vendors/Flot/jquery.flot.resize.js",
                        "~/Content/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                        "~/Content/vendors/flot-spline/js/jquery.flot.spline.min.js",
                        "~/Content/vendors/flot.curvedlines/curvedLines.js",
                        "~/Content/vendors/DateJS/build/date.js",
                        "~/Content/vendors/jqvmap/dist/jquery.vmap.js",
                        "~/Content/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                        "~/Content/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                        "~/Content/vendors/moment/min/moment.min.js",
                        "~/Content/vendors/devbridge-autocomplete/dist/jquery.autocomplete.js",
                        "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.js"));

            bundles.Add(new ScriptBundle("~/Template/js").Include(
                        "~/Content/build/js/custom.js",
                        "~/Content/vendors/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/vendors/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/Content/vendors/datatables.net-buttons/js/dataTables.buttons.min.js",
                        "~/Content/vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js",
                        "~/Content/vendors/datatables.net-buttons/js/buttons.flash.min.js",
                        "~/Content/vendors/datatables.net-buttons/js/buttons.html5.min.js",
                        "~/Content/vendors/datatables.net-buttons/js/buttons.print.min.js",
                        "~/Content/vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js",
                        "~/Content/vendors/datatables.net-keytable/js/dataTables.keyTable.min.js",
                        "~/Content/vendors/datatables.net-responsive/js/dataTables.responsive.min.js",
                        "~/Content/vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js",
                        "~/Content/vendors/datatables.net-scroller/js/dataTables.scroller.min.js",
                        "~/Content/vendors/jszip/dist/jszip.min.js",
                        "~/Content/vendors/pdfmake/build/pdfmake.min.js",
                        "~/Content/vendors/pdfmake/build/vfs_fonts.js",
                        "~/Content/vendors/select2/dist/js/select2.full.min.js",
                        "~/Content/vendors/jquery.tagsinput/src/jquery.tagsinput.js",
                        "~/Content/vendors/switchery/dist/switchery.min.js",
                        "~/Content/iCheck/icheck.min.js"));

            bundles.Add(new ScriptBundle("~/js-custom").Include(
                 "~/Script/jquery-1.10.2.min.js",
                  "~/Content/build/js/custom.min.js",
                       "~/Script/jquery.ui.autocomplete.js"));
        }
    }
}

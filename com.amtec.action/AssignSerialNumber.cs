﻿using com.amtec.forms;
using com.amtec.model;
using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using System;

namespace com.amtec.action
{
    public class AssignSerialNumber
    {
        private static IMSApiDotNet imsapi = IMSApiDotNet.loadLibrary();
        private IMSApiSessionContextStruct sessionContext;
        private InitModel init;
        private int error;
        private MainView view;

        public AssignSerialNumber(IMSApiSessionContextStruct sessionContext, InitModel init, MainView view)
        {
            this.sessionContext = sessionContext;
            this.init = init;
            this.view = view;
        }

        public int AssignSerialNumberResultCall(String serialNumber, SerialNumberData[] serialNumberArray, string workorder, int processLayer)
        {
            error = imsapi.trAssignSerialNumberForProductOrWorkOrder(sessionContext, "00110010", workorder, "-1", "-1", serialNumber, "1", processLayer, serialNumberArray, -1);
            if ((error != 0) && (error != -206))
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + "trAssignSerialNumberForProductOrWorkOrder " + error, "");
                return error;
            }
            view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + "trAssignSerialNumberForProductOrWorkOrder " + error, "");
            return error;
        }
        public int AssignSerialNumberResultCallForMul(String serialNumber, SerialNumberData[] serialNumberArray, string workorder, string station)
        {
            error = imsapi.trAssignSerialNumberForProductOrWorkOrder(sessionContext, station, workorder, "-1", "-1", serialNumber, "-1", init.currentSettings.processLayer, serialNumberArray, 0);
            LogHelper.Info("Api trAssignSerialNumberForProductOrWorkOrder: station=" + station + ",result code =" + error + ", serial number =" + serialNumber + ", work order =" + workorder + ", process layer =" + init.currentSettings.processLayer);
            if ((error != 0) && (error != -206))
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + "trAssignSerialNumberForProductOrWorkOrder " + error, "");
                return error;
            }
            view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + "trAssignSerialNumberForProductOrWorkOrder " + error, "");
            return error;
        }

        public int AssignSerialNumberResultCallForSingle(SerialNumberData[] serialNumberArray, string workorder, string station)
        {
            error = imsapi.trAssignSerialNumberForProductOrWorkOrder(sessionContext, station, workorder, "-1", "-1", "-1", "-1", init.currentSettings.processLayer, serialNumberArray, 0);
            LogHelper.Info("Api trAssignSerialNumberForProductOrWorkOrder: station=" + station + ",result code =" + error + ", work order =" + workorder + ", process layer =" + init.currentSettings.processLayer);
            if ((error != 0) && (error != -206))
            {
                view.errorHandler(2, init.lang.ERROR_API_CALL_ERROR + "trAssignSerialNumberForProductOrWorkOrder " + error, "");
                return error;
            }
            view.errorHandler(0, init.lang.ERROR_API_CALL_ERROR + "trAssignSerialNumberForProductOrWorkOrder " + error, "");
            return error;
        }
    }
}

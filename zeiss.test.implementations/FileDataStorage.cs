using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.Test.Contracts;
using Zeiss.Test.Contracts.Models;

namespace Zeiss.Test.Implementations
{
    public class FileDataStorage : IDataStorage
    {
        private readonly string _dataFilePath;

        private readonly List<EventData> _events;
        private readonly Dictionary<Guid, MachineStatusPayload> _machineStatusDataCached = new Dictionary<Guid, MachineStatusPayload>();

        private bool _isDataChanged = false;
        public FileDataStorage(string sourceFilePath)
        {
            // TODO: get file path from config
            _dataFilePath = sourceFilePath;
        }

        public void Store(IEnumerable<EventData> data)
        {
            var dataLines = data.Select(d => JsonConvert.SerializeObject(d));
            File.AppendAllLines(_dataFilePath, dataLines);
            _isDataChanged = true;
        }

        public List<EventData> GetAll()
        {
            if (!File.Exists(_dataFilePath))
            {
                return new List<EventData>();
            }

            var dataLines = File.ReadAllLines(_dataFilePath);
            _isDataChanged = false;
            _machineStatusDataCached.Clear();
            foreach (var line in dataLines)
            {
                var data = JsonConvert.DeserializeObject<EventData>(line);
                var payload = data.Payload as MachineStatusPayload;
                if (payload != null)
                {
                    _machineStatusDataCached.Add(payload.MachineId, payload);
                }

                _events.Add(data);
            }

            return _events;
        }

        public async Task StoreAsync(IEnumerable<EventData> data, CancellationToken cancellationToken)
        {
            var dataLines = data.Select(d => JsonConvert.SerializeObject(d));
            await File.AppendAllLinesAsync(_dataFilePath, dataLines, cancellationToken);
            _isDataChanged = true;
        }

        public async Task<List<EventData>> GetAllAsync(CancellationToken cancellationToken)
        {
            if (!File.Exists(_dataFilePath))
            {
                return new List<EventData>();
            }

            var dataLines = await File.ReadAllLinesAsync(_dataFilePath, cancellationToken);
            _isDataChanged = false;
            _machineStatusDataCached.Clear();
            foreach (var line in dataLines)
            {
                var data = JsonConvert.DeserializeObject<EventData>(line);
                var payload = data.Payload as MachineStatusPayload;
                if (payload != null)
                {
                    _machineStatusDataCached.Add(payload.MachineId, payload);
                }

                _events.Add(data);
            }

            return _events;
        }

        public MachineStatusPayload GetMachineStatus(Guid machineId)
        {
            if (_machineStatusDataCached.TryGetValue(machineId, out MachineStatusPayload payload))
            {
                return payload;
            }

            return null;
        }
    }
}
